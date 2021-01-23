    private void Einfügen_Click(object sender, RoutedEventArgs e)
    {
     	var itemsEnd = new List<Plan>();
    	foreach (var item in PLan.ItemsSource)
    	{
    		itemsEnd.Add(item);
    	}
    
        itemsEnd.Add(new Plan(LinieZ, Convert.ToString(Kurs.SelectedItem), AbfZ, VonZ, NachZ, AnkZ, "---"));
        Plan.ItemsSource = itemsEnd;
    }
