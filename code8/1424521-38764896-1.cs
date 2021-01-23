    public void UpdateViz(int num)
    {
        for (int i = 0; i < tbViz.Length; i++)
            tbViz[i].Visisble = (i < num);
    }
