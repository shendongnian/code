     static void Main(string[] args)
        {
            List<String> stored_data = new List<String>() { "LQI REquest","-0123456", "LQI Request", "-456789", "LQI Request", "-6789", "non valid", "12345", "extra", "12354" };
            foreach (var myString in stored_data)
            {
                var index = 0;
                if (myString.Contains("LQI"))
                {
                    index = stored_data.IndexOf(myString);
                    Console.Write((++index).ToString()+ ": ");
                    Console.Write(stored_data[index]);
                    Console.WriteLine();
                }
               
            }
            Console.ReadLine();
        }
