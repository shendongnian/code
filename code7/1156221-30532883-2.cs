        //Making a list for file1
        List<string> listFile1 = new List<string>();
        string line;
        StreamReader sr = new StreamReader("file1");
        while ((line = sr.ReadLine()) != null)
        {
            listFile1.Add(line);
        }
        sr.Close();
        //Making a list for file2
        List<string> listFile2 = new List<string>();
        string line1;
        StreamReader sr1 = new StreamReader("file2");
        while ((line1 = sr1.ReadLine()) != null)
        {
            listFile2.Add(line1);
        }
        sr1.Close();
        //Making a list for file3
        List<string> listFile3 = new List<string>();
        string line2;
        StreamReader sr2 = new StreamReader("file3");
        while ((line2 = sr2.ReadLine()) != null)
        {
            listFile3.Add(line2);
        }
        sr2.Close();
        // this will double check the emails
        foreach (string element in listFile1)
        {
            int firstCharAscii = element.Trim().ToLower()[0];
            if (firstCharAscii < 110)
            {
                // less than "n"
                if (!listFile2.Contains(element)
                    System.Console.WriteLine("file 2 is missing " + element);
                else if (listFile3.Contains(element)
                    System.Console.WriteLine("file 3 erroneously contains " + element);
            }
            else
            {
                // "n" or greater
                if (!listFile3.Contains(element)
                    System.Console.WriteLine("file 3 is missing " + element);
                else if (listFile2.Contains(element)
                    System.Console.WriteLine("file 2 erroneously contains " + element);
            }
        }
