    static void Main(string[] args)
        {
           
            List<String> stored_data = new List<String>() { "LQI REquest","-0123456", "LQI Request", "-456789", "LQI Request", "-6789", "non valid", "12345", "extra", "12354" };
            for (int j=0; j< stored_data.Count; j++)
            {
                if (stored_data[j].Contains("LQI"))
                {
                    
                    Console.Write((j).ToString()+ ": ");
                    var temp = j + 1;
                    Console.Write(stored_data[temp]);
                    Console.WriteLine();
                }
               
            }
            Console.ReadLine();
        }
