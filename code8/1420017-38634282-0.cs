    private void gridView1_MouseDown(object sender, MouseEventArgs e) {
        GridView view = (GridView)sender;
        var hi = view.CalcHitInfo(e.Location);
        Console.WriteLine(hi.HitTest);
        if (hi.InRow && !hi.InRowCell)
            DXMouseEventArgs.GetMouseArgs(e).Handled = true;
    }
