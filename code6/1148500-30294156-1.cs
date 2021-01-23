    private static void Main()
        {
            FileStream englishFile = new FileStream("English.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader engSR = new StreamReader(englishFile);
            StreamWriter engSW = new StreamWriter(englishFile);
            FileStream arabicFile = new FileStream("Arabic.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter arabSW = new StreamWriter(arabicFile);
            StreamReader arabSR = new StreamReader(arabicFile);
            try
            {
                string line = engSR.ReadLine();
                string[] arr = line.Split('|');
                int numberOfLines = int.Parse(arr[1]) + 1;
                englishFile.Seek(0, SeekOrigin.Begin);
                engSW.WriteLine("*|{0}", numberOfLines);
                arabSW.WriteLine("*|{0}", numberOfLines);
                englishFile.Seek(0, SeekOrigin.End);
                line = engSR.ReadLine();
                engSW.WriteLine("{0}|{1}", numberOfLines, "123");
                arabicFile.Seek(0, SeekOrigin.End);
                line = arabSR.ReadLine();
                arabSW.WriteLine("{0}|{1}", numberOfLines, "456");
            }
            catch
            {
            }
            finally
            {
                engSW.Close();
                arabSW.Close();
                arabSR.Close();
                engSR.Close();
                
                arabicFile.Close();
                englishFile.Close();
            }
        }
