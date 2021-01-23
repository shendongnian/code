    public void formatArrayInformation()
    {
        string[] readTxtFileAsOne = System.IO.File.ReadAllLines(@"C:\Users\test.txt");
        for (int i = 0; i < readTxtFileAsOne.Length; i++)
        {
            var txt = readTxtFileAsOne[i].ToList();
            txt.RemoveAll(x => ":,".Contains(x));
            readTxtFileAsOne[i] = new string(txt.ToArray());
        }
    }
