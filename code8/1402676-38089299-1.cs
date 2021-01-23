    public static bool checkfile(string filename)
        {
            bool same = false;
            //try
            //{
            for (i = 1; i <= inputHistories.Count; i++)
            {
                string filechf = inputHistories[i];
                try
                {
                    foreach (string line in System.IO.File.ReadAllLines(filechf))
                    {
    
                        if (line.Contains(filename))
                        {
                            same = true;
                            break;
                        }
                        else
                        {
                            same = false;
                        }
    
                    }
                }
                catch (Exception)
                {
                  //ignore if file does not exist
                }
                if (same == true)
                {
                    break;
                }
            }
