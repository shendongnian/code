    public class Visitor
    {
      private int count = 0;
      public int CountTmpFiles()
      {
        var path = Environment.ExpandEnvironmentVariables(@"c:\windows");
        VisitDir(path);
        return count;
    }
    private void VisitDir(string path)
    {
        try
        {
            foreach (var directory in Directory.GetDirectories(path))
            {
                VisitDir(directory);
            }
            foreach (var filePath in Directory.GetFiles(path))
            {
                var p = Path.GetExtension(filePath);
                if (p == ".tmp")
                {
                    count++;
                }
            }
        }
        catch (System.Exception excpt)
        {
            //Console.WriteLine(excpt.Message);
        }
    }
