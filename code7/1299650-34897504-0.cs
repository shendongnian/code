     var results = (from ta in db.Client
                               select new {
                                    Name=  ta.Name}).Distinct().ToList();
                string[] Names = new string[results.Count];
    
                for (int i = 0; i < results.Count; i++)
                  {
                      Names[i] = results[i].Name;
                  }
