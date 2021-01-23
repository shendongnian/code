    int ID=5; //you said you know the ID field
    var items = yourDataGrid.Items as ObservableCollection<CompanyModel>;
    foreach (CompanyModel m in items)
    {
         if (m.Id == ID)
         { 
            yourDataGrid.SelectedItem = item;                                   
            yourDataGrid.ScrollIntoView(yourDataGrid.SelectedItem);
            break;
         }
     }
