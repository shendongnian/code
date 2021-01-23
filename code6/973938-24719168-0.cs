    const string query = "INSERT INTO deductiblePlan (planName) VALUES (@planName)";
    
    using (var command = new SqlCommand(query, conn))
    {
        string planName ="";
        foreach (var item in CheckBoxList1.Items.Cast<ListItem>().Where(item => item.Selected))
        {
           planName =planName+item.Text
        }
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@planName",planName );
        command.ExecuteNonQuery();
    }
