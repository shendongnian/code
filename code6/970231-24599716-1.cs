    list<string> items = new List<string>();
    items.Add("Item1");
    items.Add("Item2");
    items.Add("Item3");
    items.Add("Item4");
    items.Add("Item5");
    
    foreach (var item in items.OfType<string>().Select((x, i) => new { x, i }))
    {
     int ItemNumber = item.i + 1;
     string ItemNumberStr = ItemNumber.ToString();
     PictureBox pbox = (PictureBox)panel1.Controls["Picturebox" + ItemNumberStr];
     pbox.Image = Properties.Resources.white_square_button;
     Label labl = (Label)panel1.Controls["label" + ItemNumberStr];
     labl.Text = item.x;
    }
