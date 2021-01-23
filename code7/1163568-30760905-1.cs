      public T FromXML<T>(string name, string value) where T: TblBase
                {
                    Type myType = this.GetType();
                    PropertyInfo myPropInfo = myType.GetProperty(name);
                    if (myPropInfo != null)
                    {
                        myPropInfo.SetValue(this, Convert.ChangeType(value, myPropInfo.PropertyType), null);
                    }
                    else
                    {
                        throw new MissingFieldException(string.Format("[Fieldname]wrong fieldname: {0}", name));
                    }
                    return (T)this;
                }
