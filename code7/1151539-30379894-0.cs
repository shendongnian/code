                var split = inp.Split('/');
                if(split.Length > 1)
                {
                     string yearString = split[1];
                     int yearInt = 0;
                     if(int.TryParse(yearString, out yearInt ))
                     {
                         if(yearInt > 50)
                            return split[0] + "19" + yearInt.ToString();
                         else
                            return split[0] + "20" + yearInt.ToString();
                     }
                     else
                     {
                         //handle error
                     }
                }
                else
                {
                    //handle error
                }
