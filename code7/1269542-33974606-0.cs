        static void Main(string[] args)
        {
            ...
            if (args.Length == 3) {
            //writes to the audit log and to the console when group is made w/out users
            Console.WriteLine("Group " + args[1] + " created");
            string path2 = "C:\\Files\\audit.txt";
            using (StreamWriter sw2 = File.AppendText(path2))
            {
                sw2.WriteLine("Group " + args[1] + " created");
            }
        }
        else
        {
            //writes to the audit log and to the console when user is added to a new group
