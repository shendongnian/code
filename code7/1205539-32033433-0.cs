    // Add element
    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
    	//add new item
    	RadioButton obj = new RadioButton();
    	obj.Content = "Group " + ++numberOfGroups;
    	ListBox1.Items.Add(obj);
    	
    	//select last item
    	int LastItemIndex = ListBox1.Items.Count - 1;
    	ListBox1.SelectedItem = ListBox1.Items.GetItemAt(LastItemIndex);
    }
    
    // Remove element
    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
    	//delete selected item
    	ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);
    
    	//select last item
    	int LastItemIndex = ListBox1.Items.Count - 1;
    	ListBox1.SelectedItem = ListBox1.Items.GetItemAt(LastItemIndex);
    }
