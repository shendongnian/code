    void Main()
    {
        Form f = new Form();
        FlowLayoutPanel fp = new FlowLayoutPanel();
        fp.FlowDirection = FlowDirection.LeftToRight;
        fp.Dock = DockStyle.Fill;
        f.Controls.Add(fp);
        // Get the number of buttons needed and create them in a loop    
        int numOfButtons = GetNumOfButtons();
        for (int x = 0; x < numOfButtons; x++)
        {
            Button b = new Button();
            // Define what action should be performed by the button X
            b.Tag = GetAction(x);
            b.Text = "BTN:" + x.ToString("D2");
            b.Click += onClick;
            fp.Controls.Add(b);
        }
        f.ShowDialog();
    }
    // Every button will call this event handler, but then you look at the 
    // Tag property to decide which code to execute
    void onClick(object sender, EventArgs e)
    {
        Button b = sender as Button;
        int x = Convert.ToInt32(b.Text.Split(':')[1]);
        Action<int, string> act = b.Tag as Action<int, string>;
        act.Invoke(x, b.Text);
    
    }
    // This stub creates the action for the button at index X
    // You should change it to satisfy your requirements 
    Action<int, string> GetAction(int x)
    {
        return (int i, string s) => Console.WriteLine("Button " + i.ToString() + " clicked with text=" + s);
    }
    // Another stub that you need to define the number of buttons needed
    int GetNumOfButtons()
    { 
        return 20;
    }
