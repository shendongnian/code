            foreach (var variable in list)
            {
                foreach (var VARIABLE in list)
                {
                    if (variable.Id == VARIABLE.Id)
                    {
                        continue;
                    }
                    if ((variable.FromDate <= VARIABLE.ToDate) && (variable.ToDate >= VARIABLE.FromDate))
                    {
                        Console.WriteLine("Problem Hapendes!! {0} <= {1} , {2}  >= {3}", variable.FromDate.ToString(), VARIABLE.ToDate.ToString(), VARIABLE.ToDate.ToString(), VARIABLE.FromDate.ToString());
                    }
                }
            }
