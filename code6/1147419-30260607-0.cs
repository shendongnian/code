    static void Main(string[] args)
        {
            Console.Clear(); //unnecessary
            Console.Write("Variant=");
                int vers = Int32.Parse(Console.ReadLine());
            Console.Write("Number of works=");
                int n = Int32.Parse(Console.ReadLine());
            string X = vers.ToString();
            string FileName = "Shed" + X + ".tab";
            //or string FileName = "Shed" + vers.ToString() + ".tab"; //without unnecessary X variable
            System.IO.File.WriteAllText(FileName, string.Empty); //clear file
            System.IO.StreamWriter file = new System.IO.StreamWriter(FileName);
            int ts;
            int dur;
            int tv;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i.ToString() + "-th work:");
                Console.Write("time of beginning=");
                ts = Int32.Parse(Console.ReadLine());
                Console.Write("during=");
                dur = Int32.Parse(Console.ReadLine());
                tv = ts + dur;
                file.WriteLine(ts.ToString() + "\t" + dur.ToString() + "\t" + tv.ToString());
            }
            file.Close();
        }
