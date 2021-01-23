    public T Populate<T>(params string[] @Parameters)
            {
                Type _t = typeof(T);
                dynamic _o = Activator.CreateInstance(typeof(T), null);
                
                SqlBuilder _sb = new SqlBuilder();
                _sb.Table = string.Format("{0}.{1}", _Owner, _t.Name.ToString());
                foreach (PropertyInfo p in _t.GetProperties(Utilities.BindingFlags))
                {
                    if (p.GetMethod.IsPrivate == false) _sb.Fields.Add(p.Name.ToString());
                    IEnumerable<Attribute> _attrs = p.GetCustomAttributes();
                    foreach (Attribute _a in _attrs)
                    {
                        if (_a.TypeId.ToString().Equals(typeof(Key).FullName))
                        {
                            int _position = ((Key)_a).Position;
                            try
                            {
                                string _parameter = @Parameters[_position];
                                _sb.Where.Add(string.Format("{0} = '{1}'", p.Name, _parameter));
                            }
                            catch {}
                        }
                    }
                }
    
                using (OleDbCommand _cmd = new OleDbCommand())
                {
                    _cmd.Connection = this._cn;
                    _cmd.CommandText = _sb.SQL;
                    if (_trn != null) _cmd.Transaction = _trn;
                    _cmd.CommandType = System.Data.CommandType.Text;
                    using (OleDbDataReader _reader = _cmd.ExecuteReader())
                    {
                        if (_reader.Read())
                        {
                            for (int x = 0; x < _reader.FieldCount; x++)
                            {
                                foreach (PropertyInfo p in _t.GetProperties(Utilities.BindingFlags))
                                {
                                    
                                    if (p.GetMethod.IsPrivate == false)
                                    {
                                        if (p.Name.Equals(_reader.GetName(x).ToString()))
                                        {
                                            dynamic _val = _reader.GetValue(x);
                                            if (p.ReflectedType.BaseType.Name.Equals(""))
                                            {
                                                // what goes here!
    
                                            }
                                            try
                                            {
                                                p.GetSetMethod(true).Invoke(_o, new object[] { _val });
                                            }
                                            catch { }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new DatabaseObjectNotFound(_t.Name.ToString(), string.Join(",",@Parameters));
                        }
                    }
                }
                return (T)_o;
     
            }
