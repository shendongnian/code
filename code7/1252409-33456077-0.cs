    using (StreamReader sr = File.OpenText("E:\\login.txt"))
       {
            string[] lines = File.ReadAllLines("E:\\login.txt");
            foreach (string line in lines)
            {
                string[] userPassword = line.Split(new string[] { ":" }, StringSplitOptions.None);
                if (userPassword[0] == Username && userPassword[1] == Password)
                {
                    //.....
                }
            }
        }
