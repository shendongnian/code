     List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(@"C:\Projects\ConsoleApplication1\ConsoleApplication1\bin\Debug\txt1.txt"))
            {
                string line;
                string[] parameters =  null;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line); // Add to list.
                    Console.WriteLine(line); // Write to console.
                    StringBuilder builder = new StringBuilder();
                    parameters = line.Split(',');
                    builder.Append("-n=");
                    int paramCount = 0;
                    foreach (var param in parameters)
                    {
                        if (paramCount == 0)
                        {
                            builder.Append(param + " ");
                        }
                        else if (paramCount == 2)
                        {
                            // your req seems you need static parameter here
                            // if my assumption is wrong, then correct your logic
                            builder.Append(string.Format("-dmode=convert "));
                        }
                        else if (paramCount == 3)
                        {
                            // your req seems you need static parameter here
                            // if my assumption is wrong, then correct your logic
                            builder.Append(string.Format("-volume=storage1 "));
                        }
                        else if(paramCount <= 5 )
                        {
                            builder.Append(string.Format("--{0} ", param));
                        }
                        else if (paramCount > 5)
                        {
                            //Correct the logic as per your requirement.                            
                            string sslParams = " --" + param + " ";
                            string[] sslParamvalues = parameters.Take(11).Skip(7).ToArray();
                             sslParams +=   string.Join(",", sslParamvalues);
                            builder.Append(string.Format("--{0} ", sslParams));
                        }
                        paramCount++;
                    }
                    Console.WriteLine(builder.ToString());
                    Process p = new Process();
                    p.StartInfo.FileName = @"C:\Program Files\Mytest\Mytest Tool\mytest.exe";
                    p.StartInfo.Arguments = string.Format(builder.ToString());
                    
                    //p.Start();
