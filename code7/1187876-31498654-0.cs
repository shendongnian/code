    void listBoxhaslo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listBoxhaslo = (sender as ListBox);
            if (listBoxhaslo.SelectedItem != null) 
            {
                PassForBakFile = (listBoxhaslo.SelectedItem.ToString());
                formhaslo.Hide();
            }
        }
