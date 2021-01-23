        static void Main(string[] args)
        {
            string example_input = "xxxxx Add(user1, user2) xxxxxx";
            string myArgs = getBetween2(example_input, "Add(", ")"); //myArgs = "user1, user2"
            if (myArgs != "EMPTY")
            {
                myArgs = myArgs.Replace(" ", ""); // remove spaces... myArgs = "user1,user2"
                string[] userArray = myArgs.Split(',');
                foreach (string user in userArray)
                {
                    Console.WriteLine(user);
                    //Your code here
                }
            }
            Console.ReadKey(); //pause
        }
        
        static string getBetween2(string strSource, string strStart, string strEnd)
        {
            try
            {
                int Start, End;
                if (strSource.Contains(strStart) && strSource.Contains(strEnd))
                {
                    Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                    End = strSource.IndexOf(strEnd, Start);
                    return strSource.Substring(Start, End - Start);
                }
                else
                {
                    return "EMPTY";
                }
            }
            catch
            {
                return "EMPTY";
            }
        }
