    void EditableCustomersGrid_ControlAvailable(object sender, ControlAvailableEventArgs e)
    {
         List<int> ageList = new List<int>();
         if (e.Control is DataGrid)
         {
            DataGrid dg = (DataGrid)e.Control;
            IList rows = dg.ItemsSource;
                // error here "InsuranceQuotation c"
            foreach (DataRowView c in rows )
            {
                 var yom = c["mYear"];
                 var bday = Convert.ToDateTime(yom);
                 DateTime today = DateTime.Today;
                 int age = today.Year - bday.Year;
                 if (bday > today.AddYears(-age)) age--;
                    ageList.Add(age);
            }
        }
    }
