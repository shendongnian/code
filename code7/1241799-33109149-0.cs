    var names = fullName.Split(' ');
            var formatted = new StringBuilder();
            foreach(string name in names)
            {
                if(name.Contains('-'))
                {
                    var nonHyphanatedNames = name.Split('-');
                        foreach (var nonHyphanatedName in nonHyphanatedNames)
                        {
                            formatted.Append(char.ToUpper(nonHyphanatedName[0]) + nonHyphanatedName.Substring(1).ToLower() + '-');
                        }
                       
                }
                else
                {
                    formatted.Append(char.ToUpper(name[0]) + name.Substring(1).ToLower() + ' ');
                }
                
                
            }
            //remove last field
            formatted.Remove(formatted.Length - 1, 1);
            Console.Write(formatted);
