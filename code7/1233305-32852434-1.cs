            string seedvalue = TicksToString();
            int rowNumCreate = 200000;
            int valuesInRow = 20;
            string lineInFile = seedvalue;
            string delimiter = ",";
            for (int i = 0; i < rowNumCreate; i++)
            {
                for (int t = 0; t < valuesInRow; t++)
                {
                    int skill = skill_id.Next(40);
                    string SCon = Convert.ToString(skill);
                    lineInFile += delimiter + SCon;
                }
                if (rowNumCreate >= i + 1)
                {
                    dataFile.WriteLine(lineInFile);
                    lineInFile = "";
                    string userPK = TicksToString();
                    lineInFile += userPK;
                }
            }
            dataFile.Close();
        public static string TicksToString()
        {
            long ms = DateTime.Now.Second;
            long ms2 = DateTime.Now.Millisecond;
            Random seeds;
            seeds = new Random();
            int ran = seeds.GetHashCode();
            return string.Format("{0:X}{1:X}{2:X}", ms, ms2, ran).ToLower();
        }
