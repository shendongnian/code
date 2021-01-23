    public static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (TextReader r = File.OpenText("Path")) {
             while ((s = r.ReadLine()) != null) {
                  Console.WriteLine(s);
             }
             r.Close();
          }
          File((FileSystemWatcher)sender).Dispose();
        }
