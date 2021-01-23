    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BloodDonorRegistrationConnectionString"].ToString())) {
        int insertedID;
        var cmd = "insert into Blood_Request(R_Name,R_Phone,R_Blood_Group,R_City,R_Address,Date,Time) values (@Name,@cell,@BGroup,@City,@Address,@date,@time);SELECT CAST(scope_identity() AS int)";
        using (var insertCommand = new SqlCommand(cmd, con)) {
                   insertCommand.Parameters.AddWithValue("@Name", TextBoxName.Text);
                   insertCommand.Parameters.AddWithValue("@cell", TextBoxPhone.Text);
                   insertCommand.Parameters.AddWithValue("@BGroup", dropbownBlood.SelectedItem.Text);
                   insertCommand.Parameters.AddWithValue("@City", DropDownListCity.SelectedItem.Text);
                   insertCommand.Parameters.AddWithValue("@Address", TextBoxLocation.Text);
                   insertCommand.Parameters.AddWithValue("@date", DateTime.Now.Date);
                   insertCommand.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                   con.Open();
                   insertedID = (int)insertCommand.ExecuteScalar();
        }
}
