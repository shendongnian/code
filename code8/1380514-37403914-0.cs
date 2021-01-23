    var tb = new TextBox()
    {
        Tag = new int[2,4]
    };
    tb.Text = string.Format("({0},{1})", ( tb.Tag as int[,]).GetUpperBound(0)+1, (tb.Tag as int[,]).GetUpperBound(1)+1);
