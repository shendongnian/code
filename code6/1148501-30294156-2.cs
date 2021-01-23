     private static void Main()
        {
            FileStream englishFile = new FileStream("English.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader engSR = new StreamReader(englishFile);
            StreamWriter engSW = new StreamWriter(englishFile);
            FileStream arabicFile = new FileStream("Arabic.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter arabSW = new StreamWriter(arabicFile);
            StreamReader arabSR = new StreamReader(arabicFile);
            char delimiter = '|';
            try
            {
                englishFile.Seek(0, SeekOrigin.Begin);
                
                while(!engSR.EndOfStream){
                    string line = engSR.ReadLine();
                    string[] arr = line.Split(delimiter);
                    for (int j = 0; j < arr.Count();j++ )
                    {
                        if (j > 0)
                        {
                             arabSW.Write(delimiter);
                        }
                        String outStr = ConvertStr(arr[j]);
                        arabSW.Write(outStr);
                    }
                    arabSW.Write(arabSW.NewLine);
                }
            }
            catch
            {
            }
            finally
            {
                arabSW.Close();
                //arabSR.Close();
                engSR.Close();
                //engSW.Close();
                arabicFile.Close();
                englishFile.Close();
            }
        }
