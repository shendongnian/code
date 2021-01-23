    public Point getPoint()
    {
        Button b = parentForm.Controls.Find(num + "") as Button;
        return b.Location;
    }
    public void addSnake(bool isFirst)
    {
        Button b = new Button();
        // ...
        parentForm.Controls.Add(b);
    }
