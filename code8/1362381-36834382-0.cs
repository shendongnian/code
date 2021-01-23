    List<string> medlist = new List<string>();
    private void AddMeds_Click(object sender, RoutedEventArgs e)
        {
            if (MedNameAdd.Text != null && MedQuantAdd.Text != null && QuantType.Text != null)
            {
                int i = 0;
                medlist.Add(MedNameAdd.Text + "   " + MedQuantAdd.Text + "     " + QuantType.Text);
                MedList.ItemsSource = medlist;
                Address.Text = medlist[i];
                i++; 
            }
