      List<MetroWindow> wndList = new List<MetroWindow>();
                try
                {
                    Assembly uiProject = Assembly.Load("MMS"); 
                    foreach (Type t in uiProject.GetTypes())
                    {
                        if (t.BaseType == typeof(MetroWindow))
                        {
                            var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                            if (emptyCtor != null)
                            {
                                MetroWindow f = (MetroWindow)emptyCtor.Invoke(new object[] { });
                                // t.FullName will help distinguish the unwanted entries and
                                // possibly later ignore them
                                wndList.Add(f);
                            }
                        }
                    }
                    return wndList;
                }
                catch (Exception err)
                {
                    // log exception
                    return null;
                }
