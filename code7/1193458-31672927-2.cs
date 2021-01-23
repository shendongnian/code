    private void cmbAddExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // You're not using TSC, so you don't need this either
        //using (TruckServiceClient TSC = new TruckServiceClient())
        //{
            var item = cmbAddExtras.SelectedItem as ExtraDisplayItems;
    
            if (item != null)
            {
                dgAddExtras.Items.Add(item);
            }
        //}
        btnRemoveAllExtras.Visibility = Visibility.Visible;
    }
