    public void parseString(string[] lines)
    {
        int[,] myData = new int[100, 100];
        foreach (string s in lines)
        {
            string[] data = s.Split("::");
            int x = Convert.ToInt32(data[0]);
            int y = Convert.ToInt32(data[1]);
            int value = Convert.ToInt32(data[2]);
            myData[x, y] = value;
        }
    }
