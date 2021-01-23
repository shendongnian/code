    List<string> dates = new List<string>();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("BirthDate");
                foreach (String s in company.payDays)
                {
                    DateTime compd = DateTime.Parse(s);
                    if (compd > startDate && compd < endDate)
                    {
                        dates.Add(s);
                        dt.Columns.Add(s);
                    }
                }
                foreach (Employee emp in selectedEmployees)
                {
                    var row = dt.NewRow();
                    row["Name"] = emp.getLastName() + ", " + emp.getFirstName();
                    row["BirthDate"] = emp.getDateOfBirth();
                    dt.Rows.Add(row);
                }
                mainDataGrid.AutoGenerateColumns = true;
                mainDataGrid.DataContext = dt.DefaultView;
    
    <DataGrid x:Name="mainDataGrid" DockPanel.Dock="Bottom" ItemsSource="{Binding}"  IsReadOnly="True" ClipboardCopyMode="IncludeHeader">
