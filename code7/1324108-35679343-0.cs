    static void Main(string[] args)
        {
            String a = @"SourceFilePath:C:\Users\Anuj\Desktop\Anuj Tamrakar Working Folder, BackUpFilePath:C:\Users\Anuj\Desktop\installer, SyncPath:C:\Users\Anuj\Desktop\PSI, Password:3SMpUGoJpIJdWwRDXau+OQ==, NumberOfTimes:2, Time0:10:10 AM, Time1:10:10 PM";
            Dictionary<string, string> processedString = ProcessString(a);
            //Here you can set the values to variable accessing it from the Dictionary
            var SourceFilePath = processedString["SourceFilePath"];
            var BackUpFilePath = processedString["BackUpFilePath"];
            var SyncPath = processedString["SyncPath"];
            var Password = processedString["Password"];
            var NumberOfTimes = Convert.ToInt32(processedString["NumberOfTimes"]);
            // And for the dynamic variables like Time01, Time02 I recommend you to create a list which holds all the time components.
            // Because creating a variable on the fly will be more complex for your requirement and is not necessary at this moment.
            //So you can do this
            var TimeComponents = processedString.Where(x => x.Key.StartsWith("Time")).Select(x => x).ToList();
            Console.ReadLine();
        }
