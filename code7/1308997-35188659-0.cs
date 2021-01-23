    string s1 = "E_";
    double width = 500;
    for (int i = 0; i < 2; i++)
    {
        string name_i = s1 + i.ToString();
    
        var ellipse = FindName(name_i) as Ellipse;
    
        if (ellipse != null)
        {
            ellipse.Width = width / 2;
        }
    }
