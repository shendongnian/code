    void Main()
    {
    	var f = new Form {Text = "Sample Form"};
    	// add 10 buttons and 10 labels like btn00, ... btn09 lbl00, ... lbl09
    	for (int i = 0; i < 10; i++)
    	{
    		var btn = new Button { Text = "Button" + i, 
    			Name="btn" + i.ToString().PadLeft(2,'0'), 
    			Top = i * 25, Left = 10, Width = 100 };
    		var lbl = new Label { Text = i%2 == 0?"":"Visible", 
    			Name="lbl" + i.ToString().PadLeft(2,'0'), 
    			Top = i * 24, Left = 120};
    		f.Controls.Add( btn );
    		f.Controls.Add( lbl );
    	}
    	
    	// make a button Visible = false if corrospending label is empty or null
    	foreach (Label l in f.Controls.OfType<Label>().Where( l => Regex.IsMatch(l.Name, @"lbl\d{2}")))
    	{
    		if (string.IsNullOrEmpty(l.Text))
    		{
    		   f.Controls.OfType<Button>().Single(b => b.Name == l.Name.Replace("lbl","btn")).Visible = false;
    		}
    	}
    	f.Show();
    }
