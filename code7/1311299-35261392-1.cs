	private void Form1_Load(object sender, EventArgs e)
	{
        //for demonstration purposes, we're creating 3 Drink
        //objects and adding them to the combobox. Normally
        //you would loop through a data source of some sort
        //and populate your combobox with the newly intantiated objects.
		Drink item;
		item = new Drink();
		item.Description = "Soda";
		item.Price = 1.80M;
		comboBox1.Items.Add(item);
		item = new Drink();
		item.Description = "Coffee";
		item.Price = .95M;
		comboBox1.Items.Add(item);
		item = new Drink();
		item.Description = "Tea";
		item.Price = .65M;
		comboBox1.Items.Add(item);
		
	}
