    static void Main()
        {
            FileSystemWatcher w = new FileSystemWatcher(@"C:\temp");
            
            w.Renamed += w_Renamed;
            w.EnableRaisingEvents = true;
            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
           
        }
        static void w_Renamed(object sender, RenamedEventArgs e)
        {
           //Add your logic here
        }
