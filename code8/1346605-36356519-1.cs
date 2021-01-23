    using (StreamReader reader = new StreamReader("C:\\Users\\Sparta\\Documents\\Visual Studio 2015\\WebSites\\WebSite4\\u22b.txt"))
    {
        string line = null;
        LinkedList list = new LinkedList();
        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(';');
            ProjectWork temp = new ProjectWork(values[0], values[1], int.Parse(values[2]));
            list.AddToEnd(temp);
        }            
    }
