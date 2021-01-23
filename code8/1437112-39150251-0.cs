    for( int i = 0; i < 8; i++)
    {
        FlowLayoutPanel name = new FlowLayoutPanel();
        FlowLayoutPanel data = new FlowLayoutPanel();
        FlowLayoutPanel pic = new FlowLayoutPanel();
    
        SearchR.Searchrdata.Controls.Add(first);
        first.Margin = new Padding(50, 50, 3, 50);
        first.Size = new Size(320, 320);
        first.BackColor = Color.Azure;
        first.Controls.Add(name);
        name.Size = new Size(320, 22);
        name.Margin = new Padding(0);
        first.Controls.Add(data);
        data.Size = new Size(320, 22);
        data.Margin = new Padding(0);
        first.Controls.Add(pic);
        pic.Size = new Size(320, 276);
        pic.Margin = new Padding(0);
        SearchR.Searchrdata.Controls.Add(two);
        two.Margin = new Padding(0, 50, 3, 50);
        two.Size = new Size(320, 320);
        two.BackColor = Color.DarkGray;
        two.Controls.Add(name);
        name.Size = new Size(320, 22);
        name.Margin = new Padding(0);
        two.Controls.Add(data);
        data.Size = new Size(320, 22);
        data.Margin = new Padding(0);
        two.Controls.Add(pic);
        pic.Size = new Size(320, 276);
        pic.Margin = new Padding(0);
        SearchR.Searchrdata.Controls.Add(last);
        last.Margin = new Padding(0, 50, 10, 50);
        last.Size = new Size(320, 320);
        last.BackColor = Color.Bisque;
        last.Controls.Add(name);
        name.Size = new Size(320, 22);
        name.Margin = new Padding(0);
        last.Controls.Add(data);
        data.Size = new Size(320, 22);
        data.Margin = new Padding(0);
        last.Controls.Add(pic);
        pic.Size = new Size(320, 276);
        pic.Margin = new Padding(0);
        }
    
    
    
    }
    return null;
