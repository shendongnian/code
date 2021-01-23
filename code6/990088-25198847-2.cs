    private static void AssignBar(string name)
    {
        if(BarInstance!=null)
        {
            BarInstance.Dispose();
        }
        BarInstance = new Bar(name);
    }
