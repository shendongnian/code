    private void cmbAddExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        using (DataEntities DE = new DataEntities())
        {
            tblExtra E = (tblExtra)cmbAddExtras.SelectedItem;
            List<tblExtra> items = new List<tblExtra> { E };
    
            items.Where(item => item != null).ToList().ForEach(i =>
            {
                dgAddExtras.Items.Add(i);
            });
        }
    }
