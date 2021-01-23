    SqlCommand cmd = new SqlCommand("update Members set MemberID=@MemberID, Name=@Name, Gender=@Gender, Address=@Address, NID=@NID, DOB=@DOB, BloodGroup=@BloodGroup, Height=@Height, Weight=@Weight, ChestSize=@ChestSize, MusclesSizes=@MusclesSizes, AbsPack=@AbsPack, Profession=@Profession, Contact=@Contact" + " where MemberID=@MemberID", Connection);
    cmd.Parameters.AddWithValue("@MemberID", MemberIDTextBox.Text);
    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
    // ...
    //Keep adding parameters
    cmd.ExecuteNonQuery();
