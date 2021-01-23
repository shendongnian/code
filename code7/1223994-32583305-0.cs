    public void MyFunction()
    {
        for (int i = ...)
        {
            if (i < 0 || i >= blocks.Count)
            {
                System.IO.File.AppendAllText(@"error.log", "Error in MyFunction(), i = " + i + ", blocks.Count = " + blocks.Count);
            }
   
            blocks[i].SetValue(...);
        }
    }
