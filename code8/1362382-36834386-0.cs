    List<string> medlist = new List<string>();
    
    private void AddMeds_Click(object sender, RoutedEventArgs e)
    {
    	if (MedNameAdd.Text != null && MedQuantAdd.Text != null && QuantType.Text != null)
    	{	
    		medlist.Add(MedNameAdd.Text + "   " + MedQuantAdd.Text + "     " + QuantType.Text);
    		MedList.ItemsSource = medlist;
    		Address.Text = medlist.LastOrDefault(); // shows last added item.    
    	}
    }
