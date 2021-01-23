                dynamic r = new System.Dynamic.ExpandoObject();  
                properties.AsParallel().ForAll(   
                    p => (r as IDictionary<string, object>).Add(p,   
                    data.GetType().GetProperty(p).GetValue(data, null)));  
                return r;  
            });  
            Console.WriteLine(result.Last().Place); //def  
