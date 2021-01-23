    foreach (IMetricContract contract in metrics)
                {
                    name = contract.Name;
                    desc = contract.Description;
                    
                    Console.Write("".PadRight(13,'#')+name.PadRight(41,'i'));
                    Console.WriteLine(desc + "\n");
    
                }
