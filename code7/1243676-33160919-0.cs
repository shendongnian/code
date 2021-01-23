    int xCount = 4;
    int yCount = 4;
    int buttonSize = 40;
    Dictionary<Button, Point> pointByButton = new Dictionary<Button, Point>();
    for (int x = 0; x < xCount; ++x)
    {
        for (int y = 0; y < yCount; ++y)
        {
            Button newButton = new Button();
            newButton.Location = new Point(100 + x * buttonSize, 150 + y * buttonSize);
            newButton.Size = new Size(buttonSize, buttonSize);
            newButton.Name = "" + (char)(y + 'A') + (x + 1);
            newButton.Text = newButton.Name;
            this.Controls.Add(newButton);
            pointByButton.Add(newButton, new Point(x, y));
            newButton.Click += new EventHandler((s, ev) =>
            {
                Point thisPoint = pointByButton[(Button)s];
                foreach (var btn in pointByButton)
                {
                    if (btn.Value.Y - thisPoint.Y != -1 || Math.Abs(btn.Value.X - thisPoint.X) != 1)
                    {
                        btn.Key.Enabled = false;
                    }
                }
            });
        }
    }
