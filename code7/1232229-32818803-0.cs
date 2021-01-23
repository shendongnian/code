                string username = "mary maverick";
                string password = "Test123%mave";
                username = username.Replace(" ", "");
                for (int i = 0; i < password.Length; i++)
                {
                    if (i + 4 <= password.Length)
                    {
                        string temp = password.Substring(i,  4);
                        if (username.Contains(temp))
                        {
                            Console.WriteLine("Faild!");
                            return;
                        }
                    }
                }
                Console.WriteLine("Accepted!");
