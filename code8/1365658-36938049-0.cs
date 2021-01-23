    // form fields
    bool pressed;
    List<Point> path;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (!pressed)
        {
            pressed = true;
            path = new List<Point>();
            path.Add(e.Location);
        }
        else
        {
            pressed = false;
            // calculate distance from List
            // log distance
        }
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (pressed)
        {
            path.Add(e.Location);
        }
    }
