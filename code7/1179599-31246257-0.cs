    private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            WritePadFileContent listitem = null;
            int SelectedContactID = 0;
            if (listBoxobj.SelectedIndex != -1)
            {
                //Get slected listbox item contact ID
                listitem = FileContents[listBoxobj.SelectedIndex]; 
                SelectedContactID = listitem.Id;
            }
    
    
    
            //code for export to pdf, it works
        }
