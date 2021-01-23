                foreach (var a in ((Newtonsoft.Json.Linq.JProperty)(el)))
                {
                    int i = 0;
                    foreach (var value in ((Newtonsoft.Json.Linq.JObject)(a)))
                    {
                        i = i + Convert.ToInt32(value.Value);
                        Console.WriteLine(value.Value);
                    }
                    if (i != 0)
                    {
                        el.Parent["count"] = i;
                    }
                    else {
                        el.Parent["count"] = 0;
                    }
                }
            
