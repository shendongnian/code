    Visibility[] tbViz = new Visibility[10];
    public Visibility[] TbViz { get { return tbViz; } }
    public void UpdateViz(int num)
    {
        for (int i = 0; i < tbViz.Length; i++)
        {
            if (i < num)
                tbViz[i] = System.Windows.Visibility.Visible;
            else
                tbViz[i] = System.Windows.Visibility.Hidden;
        }
    
    }
    Visisbility="{binding path=TbViz[0]}" 
