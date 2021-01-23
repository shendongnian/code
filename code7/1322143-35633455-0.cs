         string text="TestText";
         var dir = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "yourAppName");
         if (Directory.Exists(dir) == false)
    				{
    					Directory.CreateDirectory(dir);
    				}
           string dbFileSDCard = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "youAppName/YourFile.txt");
           System.IO.File.WriteAllText(@dbFileSDCard, text);
