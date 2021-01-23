    foreach (UIElement oldElem in Canvas1.Children)
                {
                    try
                    {               
                            Type t = oldElem.GetType();
                            UIElement newElem = (UIElement)Activator.CreateInstance(t);
                            
                            PropertyInfo[] info = t.GetProperties();
                            int i = 0;
                            foreach (PropertyInfo pinfo in info)
                            {
                                if (pinfo.Name == "Name") continue;
                                try
                                {
                                    if (pinfo.GetSetMethod() != null) // avoid read-only properties
                                        pinfo.SetValue(newElem, pinfo.GetValue(oldElem, null),null);
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine((++i).ToString() + " : " + pinfo.ToString());
                                }
                            }
    
                            Canvas.SetLeft(newElem, Canvas.GetLeft((oldElem)));
                            Canvas.SetTop(newElem, Canvas.GetTop((oldElem)));
                            
    
                            Canvas2.Children.Add(newElem);
                        }
                    
                    catch (Exception ex)
                    { 
                    
                    }
                }
