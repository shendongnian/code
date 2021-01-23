     using (StreamReader oReader = new StreamReader("your_file_path))
     {
            while ((sLine = oReader.ReadLine()) != null)
            {
                 string[] sLineItems = sLine.Split('\t');// Assuming the file is tab delimited.
                 Console.WriteLine(sLineItems[0],sLineItems[3]);
            }
     }
