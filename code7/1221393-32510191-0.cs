    static void Main(string[] args) {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var subDirectories = Directory.GetFiles(@"C:\Users\ertdiddy\Documents\Visual Studio 2013\Projects", "*.*", SearchOption.AllDirectories);
                sw.Stop();
    
                var getFileTime = sw.Elapsed.TotalSeconds;
                sw.Reset();
                Console.WriteLine(getFileTime);
    
                sw.Start();
                var subDirectories2 = Directory.EnumerateFiles(@"C:\Users\ertdiddy\Documents\Visual Studio 2013\Projects", "*.*", SearchOption.AllDirectories);
                sw.Stop();
    
                var enumErateFileTime = sw.Elapsed.TotalSeconds;
    
                Console.WriteLine(enumErateFileTime);
        //Output:
        //GetFiles() = 0.499075 seconds
        //EnumerateFiles() = 0.0001175 seconds
            }
