    <DataGrid Name="DG1" ItemsSource="{Binding}" AutoGenerateColumns="True" 
        AutoGeneratingColumn="DG1_AutoGeneratingColumn" />
...
    //Access and update columns during autogeneration 
    private void DG1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string headername = e.Column.Header.ToString();
    
        //Cancel the column you don't want to generate 
        if (headername == "MiddleName")
        {
            e.Cancel = true;
        }
    
        //update column details when generating 
        if (headername == "FirstName")
        {
            e.Column.Header = "First Name";
        }
        else if (headername == "LastName")
        {
            e.Column.Header = "Last Name";
        }
        else if (headername == "EmailAddress")
        {
            e.Column.Header = "Email";
    
        }
    
    }
