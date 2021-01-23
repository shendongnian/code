    foreach (string profile in userProfiles)
            {
                int maxuser = 100;
                if (profile.Equals("astd"))
                    maxuser = 300;
                foreach (string suffix in suffixes)
                {
                    for (int i = 0; i <= maxuser; i++)
                    {
                        string prefix = profile;
                        Console.WriteLine("prefix" + prefix);
                        string num = i.ToString();
                        if (num.Length < 2)
                            num = "0" + num;
                        string postfix = num;
                        string username = prefix + postfix + suffix;
                        Console.WriteLine(username);
                        //TODO add a
                        Gson gson = new Gson();
                        User u = new User();
                        // u.setFirstName(username);
                    }
                }
            }
