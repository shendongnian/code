    List<string[]> itemsList = new List<string[]>(); //declare this outside of the method
    public static void fillArray()
    {
        string[] linesInFile = File.ReadAllLines(GlobalVariables.filePath);
        //EACH LINE IS A STRING AT THIS POINT
        foreach (string s in linesInFile)
        {
            string[] items = s.Split(';');
            itemsList.Add(items); //add the list in the itemsList
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
                //Console.WriteLine(items[1]);
            }
        }
    }
