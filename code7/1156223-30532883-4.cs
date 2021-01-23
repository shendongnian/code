        //Making a list for file1
        HashSet<string> listFile1 = new HashSet<string>();
        string line;
        StreamReader sr = new StreamReader("file1");
        while ((line = sr.ReadLine()) != null)
        {
            listFile1.Add(line);
        }
        sr.Close();
        //Making a list for file2
        HashSet<string> listFile2 = new HashSet<string>();
        string line1;
        StreamReader sr1 = new StreamReader("file2");
        while ((line1 = sr1.ReadLine()) != null)
        {
            listFile2.Add(line1);
        }
        sr1.Close();
        //Making a list for file3
        HashSet<string> listFile3 = new HashSet<string>();
        string line2;
        StreamReader sr2 = new StreamReader("file3");
        while ((line2 = sr2.ReadLine()) != null)
        {
            listFile3.Add(line2);
        }
        sr2.Close();
        IEnumerable<string> allEmails = listFile1.Union(listFile2).Union(listFile3);
        // this will double check the emails
        foreach (string element in allEmails)
        {
            int firstCharAscii = element.Trim().ToLower()[0];
            if (firstCharAscii < 110)
            {
                // less than "n"
                if (!listFile2.Contains(element))
                    System.Console.WriteLine("file 2 is missing " + element);
                if (listFile3.Contains(element))
                    System.Console.WriteLine("file 3 erroneously contains " + element);
            }
            else
            {
                // "n" or greater
                if (!listFile3.Contains(element))
                    System.Console.WriteLine("file 3 is missing " + element);
                if (listFile2.Contains(element))
                    System.Console.WriteLine("file 2 erroneously contains " + element);
            }
        }
