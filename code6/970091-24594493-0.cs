    public class Program 
    {
        public int Main()
        {
            string original_path = System.IO.Path.GetFullPath(@"\\remote\app.exe");
            string current_path = System.IO.Path.GetFullPath(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            if(original_path == current_path){
                System.IO.File.Copy(original_path, @"C:\foo\bar\app.exe", true);
                System.Diagnostics.Process.Start(@"C:\foo\bar\app.exe");
                return 0;
            }
            
            // Run program normally here
        }
    }
