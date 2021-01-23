    class Entry
    {
        public string Text;
        public Brush Color;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Add(new Entry { Text = "Purple", Color = Brushes.Purple });
        listBox1.Items.Add(new Entry { Text = "Green",  Color = Brushes.Green  });
        listBox1.Items.Add(new Entry { Text = "Red",    Color = Brushes.Red    });
    }
    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        var currentItem = listBox1.Items[e.Index] as Entry;
        e.DrawBackground();
        e.Graphics.DrawString(currentItem.Text, listBox1.Font, currentItem.Color,
                              e.Bounds, StringFormat.GenericDefault);
        e.DrawFocusRectangle();
    }
