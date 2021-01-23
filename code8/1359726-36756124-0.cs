    public static void Main()
        {
            Zumba table = new Zumba();
            int[,] zumValues = table.ZumbaValues;
            string[] zumForm = new string[6] { "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
            int r = 0;
            while (r < zumValues.GetLength(0))
            {
                //Write the day
                Console.Write("{0}", zumForm[r]);
                //right the zumba values
                for (int c = 0; c < zumValues.GetLength(1); c++)
                    Console.Write("\t" + zumValues[r, c] + "\t");   
                //new Line             
                Console.Write("\n");
                r++;
            }
            
            Console.ReadLine();
        }
