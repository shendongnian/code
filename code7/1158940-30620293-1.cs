    string updateApple = @"Update Appel_offre Set 
                                Titre_ao = @Titre_ao,
                                Description_ao = @Description_ao,
                                Cout           = @Cout,
                                Type           = @Type,
                                Date           = @Date,
                                Echeance       = @Echeance,
                                Reference      = @Reference,
                                Piece_jointe   = @Piece_jointe,
                                filename       = @filename
                            where Id_ao = @Id_ao;";
    string updateLot = @"Update Lot Set 
                                Description    = @Description,
                                Reference      = @Cout,
                                Type           = @Type
                         where Titre = @Titre;";
    using (var cnx = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["str"].ConnectionString))
    using(var cmd_UpdateApple = new SqlCommand(updateApple, cnx))
    using (var cmd_UpdateLot = new SqlCommand(updateLot, cnx))
    {
        cmd_UpdateApple.Parameters.Add("@Titre_ao", SqlDbType.VarChar).Value = TextBox4.Text;
        cmd_UpdateApple.Parameters.Add("@Description_ao", SqlDbType.VarChar).Value = TextBox5.Text;
        // ...
        cmd_UpdateApple.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Parse(TextBox8.Text);
        // ...
        cnx.Open();
        int updatedAppels = cmd_UpdateApple.ExecuteNonQuery();
        cmd_UpdateLot.Parameters.Add("@Description", SqlDbType.VarChar).Value = TextBox2.Text.Text;
        // ...
        cmd_UpdateLot.Parameters.Add("@Titre", SqlDbType.VarChar).Value = Dropdownlst.SelectedItem.Value;
        int updatedLot = cmd_UpdateApple.ExecuteNonQuery();
    }
