            //path of file and there is no need of creating filestream now
            using (StreamWriter w = File.AppendText(path))
            {
               for (int y = 0; y <= 3; y++)
                {
                  Writer.WriteLine(dataLine);  
                  dataLine = sr.ReadLine();  
                }
                w.Close();
            }
