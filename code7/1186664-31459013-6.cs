    private void button1_Click(object sender, RoutedEventArgs e)
    {
        List<string> selectedFOP = new List<String>();
            
        foreach (BoolStringClass item in listBoxZone.Items)
        {
            if (item == true)
            {
                selectedFOP.Add(item.ToString());
            }
        }
   }
