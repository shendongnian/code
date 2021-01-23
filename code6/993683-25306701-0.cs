                    List<string> lst01 = new List<string>();
                    lst01.Add("1");
                    lst01.Add("999");
                    lst01.Add("888");
    
                    List<string> lst02 = new List<string>();
                    lst02.Add("4");
                    lst02.Add("5");
                    lst02.Add("6");
    
                    string myString = "123";
                    var r1 = lst01.Any(w => myString.Contains(w));
                    var r2 = lst02.Any(w => myString.Contains(w));
