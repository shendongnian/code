     static void Main(string[] args)
                {
                    string[] spam = new string[] { "test", "ak", "admin", "againadmin" };
                    string email = "Its great to see that admin ak is not perfroming test.";
                    string email1 = "Its great to see that admin ak is not perfroming test againadmin.";
        
                    if (SpamChecker(spam, email))
                    {
                        Console.WriteLine("email spam");
                    }
                    else 
                    {
                        Console.WriteLine("email not spam");
                    }
        
                    if (SpamChecker(spam, email1))
                    {
                        Console.WriteLine("email1 spam");
                    }
                    else
                    {
                        Console.WriteLine("email1 not spam");
                    }
        
                    Console.Read();
                }
        
                private static bool SpamChecker(string[] spam, string email)
                {
                    int score = 0;
                    foreach (var item in spam)
                    {
                        score += Regex.Matches(email, item, RegexOptions.Compiled | RegexOptions.IgnoreCase).Count;
                        if (score > 3) // change count as per desired count
                        {
                            return true;
                        }
                    }
        
                    return false;
                }
