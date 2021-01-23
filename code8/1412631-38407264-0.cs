    public void formatArrayInformation()
    {
        string[] readTxtFileAsOne = System.IO.File.ReadAllLines(@"C:\Users\test.txt");
        for (int i = 0; i < readTxtFileAsOne.Length; i++)
        {
            readTxtFileAsOne[i] = readTxtFileAsOne[i].Replace(":", " ").Replace(",", " ");
        }
    }
