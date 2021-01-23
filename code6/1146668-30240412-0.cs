    static void Main(string[] args)
    {
        String Readfiles = File.ReadAllText(@"C:\Users\ken4ward\Desktop\Tidy\WriteLines.txt");
        Int32 myInt = Int32.Parse(Readfiles);
        //Declare array outside the loop
        String[] start = new String[myInt];
        for (int i = 0; i < myInt; ++i)
        {
            //Populate the array with the value (add one so it starts with 1 instead of 0)
            start[i] = (i + 1).ToString();
            Console.WriteLine(i);
            Console.ReadLine();  
        }
        //Write to the file once the array is populated
        File.WriteAllLines(@"C:\Users\ken4ward\Desktop\Tidy\writing.txt", start);
    }
