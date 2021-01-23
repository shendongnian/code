                string[] str = split[1].Split('/');
                // create a new DateTime
                int minutes = int.Parse(str[1]);
                if(minutes >= 30)
                      hour = int.Parse(str[0]) + 1 // make sure if it 13 or 25 make it 1
                      minutes = 0 ;
                      sec = 0;
                else {
                     hour = int.Parse(str[0]);
                     minutes = 0 ;
                     sec = 0 ;
                }
                var myDate = new Date(Year, month , day , hour , minutes , sec);
