    OpenFileDialog txtopen = new OpenFileDialog();
    if (txtopen.ShowDialog() == DialogResult.OK)
    {
    	list.Clear();	// <-- clear here
    		
    	string FileName = txtopen.FileName;
    	string line;
    	System.IO.StreamReader file = new System.IO.StreamReader(FileName.ToString());
    	while ((line = file.ReadLine()) != null)
    	{
    		list.Add(double.Parse(line));
    	}
    	//To print the arraylist
    	foreach (double s in list)
    	{
    		Console.WriteLine(s);
    	}
    }
