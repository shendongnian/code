    public void HandleHtml()
    
    ...    
    
    List<Tuple<string, Jobbot.Property>> results = new List<Tuple<string, Jobbot.Property>>();
    
    ...
    
                                if (item.Attributes["href"].Value.StartsWith("http://"))
                                {
                                    results.Add(Tuple.Create(item.Attributes["href"].Value, data));
                                    Console.WriteLine(item.Attributes["href"].Value);
                                }
