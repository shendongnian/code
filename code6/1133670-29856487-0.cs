    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader(@"C:\Path\To\File.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] stuff = line.Split(',');
                int id = Convert.ToInt32(stuff[0]);
                string name = stuff[1];
                int val = Convert.ToInt32(stuff[2]);
                double commission = (double)val * 0.05;
                Console.WriteLine(name + "'s Commission: " + commission.ToString());
            }
        }
    }
 
