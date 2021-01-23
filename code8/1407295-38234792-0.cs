    public void Example()
    {
        // Using a statement lambda to wrap the call
        foreach (ComboBox box in boxes)
        {
            box.SelectedIndexChanged += new EventHandler((sender, e) =>
            {
                Box_Changed_Example1(boxes, sender, e);
            });
        }
        // Or, use the .Tag property to store the data
        foreach (ComboBox box in boxes)
        {
            box.Tag = boxes;
            box.SelectedIndexChanged += new EventHandler(Box_Changed_Example2);
        }
    }
    void Box_Changed_Example1(ComboBox[] boxes, object sender, EventArgs e)
    {
        // TODO
    }
    void Box_Changed_Example2(object sender, EventArgs e)
    {
        ComboBox[] boxes = (ComboBox[])((ComboBox)sender).Tag;
        // TODO
    }
