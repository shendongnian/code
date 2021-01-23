    DataTable medicines= new DataTable();
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        try
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select MedicineName,MedicineId from MedicineMaster where MedicineType = '" + MedType + "'", con);
            adapter.Fill(subjects);
            ddMedName.DataSource = subjects;
            ddMedName.DataTextField = "MedicineName";
            ddMedName.DataValueField = "MedicineId";
            ddMedName.DataBind();
        }
        catch (Exception ex)
        {
            // Handle the error
        }
      
    }
    // Add the initial item - you can add this even if the options from the
    // db were not successfully loaded
    ddMedName.Items.Insert(0, new ListItem("-Select-", "0"));
