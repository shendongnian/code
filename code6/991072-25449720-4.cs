        Control cloned1 = (Control)DeepClone(dataGridView1); 
        cloned1.SetBounds(cloned1.Location.X, cloned1.Location.Y + 300, cloned1.Width, ct1.Height);
        Controls.Add(cloned1);
        cloned1.Show();
        public dynamic DeepClone(dynamic ob1)
        {
            dynamic ob2 = null;
            if (ob1.GetType().IsSerializable && !ob1.GetType().IsArray)
            {
                if (ob1 != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, ob1);
                        ms.Position = 0;
                        ob2 = formatter.Deserialize(ms);
                    }
                }
            }
            else
            {
                if (ob1.GetType().IsArray)
                {
                    var r1 = ob1.Rank;
                    object[] d1 = new object[r1];
                    long[] V1 = new long[r1];
                    for (int i = 0; i < r1; i++)
                    {
                        V1[i] = 0;
                        d1[i] = ob1.GetUpperBound(i) + 1;
                    }
                    ob2 = Activator.CreateInstance(ob1.GetType(), d1);
                    for (long i = 0; i <= ob2.Length; i++)
                    {
                        ob2.SetValue(DeepClone(ob1.GetValue(V1)), V1);
                        for (int j = 0; j <= V1.GetUpperBound(0); j++)
                        {
                            if (V1[j] < ob2.GetUpperBound(j))
                            {
                                V1[j]++;
                                break;
                            }
                            else
                            {
                                V1[j] = 0;
                            }
                        }
                    }
                }
                else
                {
                    PropertyInfo[] P1 = ob1.GetType().GetProperties();
                    ob2 = Activator.CreateInstance(ob1.GetType());
                    foreach (PropertyInfo p1 in P1)
                    {
                        try
                        {
                            if (p1.PropertyType.GetInterface("System.Collections.ICollection", true) != null)
                            {
                                dynamic V2 = p1.GetValue(ob1) as IEnumerable;
                                MethodInfo gm1 = p1.PropertyType.GetMethods().Where(m => m.Name == "Add").Where(p => p.GetParameters().Count() == 1).First(f => V2[0].GetType().IsSubclassOf(f.GetParameters()[0].ParameterType) || f.GetParameters()[0].ParameterType == V2[0].GetType());
                                if (V2[0].GetType().IsSubclassOf(gm1.GetParameters()[0].ParameterType) || gm1.GetParameters()[0].ParameterType == V2[0].GetType())
                                {
                                    for (int i = 0; i < V2.Count; i++)
                                    {
                                        dynamic V3 = DeepClone(V2[i]);
                                        gm1.Invoke(p1.GetValue(ob2), new[] {V3});
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    foreach (PropertyInfo p1 in P1)
                    {
                        try
                        {
                            if (p1.PropertyType.IsSerializable && p1.CanWrite)
                            {
                                var v2 = p1.GetValue(ob1);
                                p1.SetValue(ob2, v2);
                            }
                            if (!p1.PropertyType.IsSerializable && p1.CanWrite)
                            {
                                dynamic V2 = p1.GetValue(ob1);
                                if (p1.PropertyType.GetMethod("Clone") != null)
                                {
                                    dynamic v1 = V2.Clone();
                                    p1.SetValue(ob2, v1);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            return ob2;
        }
