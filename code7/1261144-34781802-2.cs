    string Results = Encode(0.04036483168558814);
//==========================================
 
            private string Encode(double input)
            {
    
                var result = new Stack<char>();
                char[] clistarr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
                Int64 inputValInt = 0;
                string inputValP = "";
                double inputValN = 0;
                string ReturnsVal = "";
                if (input.ToString() != "")
                {
                    try
                    {
                        if (input.ToString().Contains("."))
                        {
                            inputValP = input.ToString().Substring(0, input.ToString().IndexOf("."));
    
                            inputValInt = Int64.Parse(inputValP);
                            if (inputValInt != 0)
                            {
                                while (inputValInt != 0)
                                {
                                    result.Push(clistarr[inputValInt % 36]);
                                    inputValInt /= 36;
                                }
                                char[] RevArr1 = result.ToArray();
                                Array.Reverse(RevArr1);
                                result = new Stack<char>();
                                for (int i = (RevArr1.Length - 1); i >= 0; i--)
                                {
                                    result.Push(RevArr1[i]);
                                }
                                result.Push('.');
                            }
                            else
                            {
                                result.Push('0');
                                result.Push('.');
                            }
                            inputValN = input - inputValInt;
                            double inputVal = inputValN;
    
                            int CountLoop = 0;
                            while (CountLoop < 11)
                            {
    
                                double tempVal = (inputVal * 36);
                                int Start = tempVal.ToString("R").IndexOf(".");
                                if (Start > 0)
                                {
                                    inputValP = tempVal.ToString("R").Substring(0, Start);
    
                                    int TopVal = Int16.Parse(inputValP);
                                    result.Push(clistarr[TopVal]);
                                    inputVal = tempVal - TopVal;
                                }
                                CountLoop++;
                            }
                            char[] RevArr = result.ToArray();
                            Array.Reverse(RevArr);
                            ReturnsVal = new string(RevArr);
                        }
                        else
                        {
                            inputValInt = Convert.ToInt64(input);
                            while (inputValInt != 0)
                            {
                                result.Push(clistarr[inputValInt % 36]);
                                inputValInt /= 36;
                            }
                            char[] RevArr = result.ToArray();
                            ReturnsVal = new string(RevArr);
                        }
    
                    }
                    catch (Exception ee)
                    {
                        return ("");
                    }
                }
                else
                {
                    return ("");
                }
                return (ReturnsVal);
            }
