    var result = new Result();
                            
                result.Add(new Review { Name = "ABC", Amount = 5 });
                result.Add(new Review { Name = "DEF", Amount = 4 });
                result.Add(new Review { Name = "ABC", Amount = 1 });
                result.Add(new Review { Name = "WRA", Amount = 4 });
                result.Add(new Review { Name = "ABC", Amount = 2 });
                result.Add(new Review { Name = "ARA", Amount = 4 });
    
                foreach (Review r in result.Reviews)
                {
                    MessageBox.Show(r.Name + ": " + r.Amount);
                }
