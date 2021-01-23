                foreach (UIElement oldElem in Canvas1.Children)
                {
                    Type t = oldElem.GetType();
                    UIElement newElem = (UIElement)Activator.CreateInstance(t);
                    PropertyInfo[] info = t.GetProperties();
                    int i = 0;
                    foreach (PropertyInfo pinfo in info)
                    {
                        try
                        {
                            if (pinfo.SetMethod != null) // avoid read-only properties
                                pinfo.SetValue(newElem, pinfo.GetValue(oldElem));                        
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine((++i).ToString() + " : " + pinfo.ToString());
                        }
                    }
    
                    Canvas.SetLeft(newElem, Canvas.GetLeft((oldElem)));
                    Canvas.SetTop(newElem, Canvas.GetTop((oldElem)));
                    Canvas.SetRight(newElem, Canvas.GetRight((oldElem)));
                    Canvas.SetBottom(newElem, Canvas.GetBottom((oldElem)));
    
                    Canvas2.Children.Add(newElem);
                }
