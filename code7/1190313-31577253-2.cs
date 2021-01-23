    dynamic obj = JObject.Parse(json);
                foreach (var o in obj.UserProperties)
                {
                    var sb = new StringBuilder();
                    sb.Append(o.Id);
                    sb.Append(":");
    
                    bool hasProps = false;
    
                    foreach (var value in o.values)
                    {
                        if (value.prop1 != null)
                        {
                            sb.Append(value.prop1);
                            sb.Append(',');
                            hasProps = true;
                        }
                        if (value.prop2 != null)
                        {
                            sb.Append(value.prop2);
                            sb.Append(',');
                            hasProps = true;
                        }
                        if (value.prop3 != null)
                        {
                            sb.Append(value.prop3);
                            sb.Append(',');
                            hasProps = true;
                        }
                    }
    
                    if (hasProps)
                    {
                        sb.Remove(sb.Length - 1, 1); // Remove trailing comma
                    }
    
                    Console.WriteLine(sb.ToString());
                }
                Console.ReadLine();
