    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        Rectangle inner = hitbox;
        Rectangle outer = hitbox;
        inner.Inflate(-1, -1);  // a two pixel
        outer.Inflate(1, 1);    // ..outline
        if (outer.Contains(e.Location) && !innerContains(e.Location)) .. // clicked on outline
    }
