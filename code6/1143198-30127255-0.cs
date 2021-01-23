    class Program
    {
        static string path;
        static int file = 0;
        static void Main(string[] args)
        {
            new_file();
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789+-*_!$£^=<>§°ÖÄÜöäü.;:,?{}[]";
            var q = alphabet.Select(x => x.ToString());
            int size = 3;
            int counter = 0;
    
            for (int i = 0; i < size - 1; i++)
            {
                q = q.SelectMany(x => alphabet, (x, y) => x + y);
            }
    	
    		StreamWriter sw = File.AppendText(path);
    		
    		try
    		{
    			foreach (var item in q)
    			{
    				if (counter >= 20000000)
    				{
    					sw.Dispose();
    					new_file();
    					counter = 0;
    				}
    				sw.WriteLine(item);
     				Console.WriteLine(item);
    			}
    		}
    		finally
    		{
    			if(sw != null)
    			{
    				sw.Dispose();
    			}
    		}
        }
    
        static void new_file()
        {
            path = @"C:\temp\list" + file + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                }
            }
            file++;
        }
    }
