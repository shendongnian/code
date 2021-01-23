    var command = new SqlCommand("Select * From T_ExhibitorLocation 
            where F_ExhibitionCode=@Cmbexhibition 
              and F_ExhibitorCode=@exhibitioncode
              and F_Site=@site");
    SqlParameter param1  = new SqlParameter();
    param1.ParameterName = "@Cmbexhibition";
    param1.Value         = Cmb_Exhibition.SelectedValue.ToString();
    
    SqlParameter param2  = new SqlParameter();
    param2.ParameterName = "@exhibitioncode";
    param2.Value         = Trim(Txt_ExhibitorID.Text);
    
    SqlParameter param3  = new SqlParameter();
    para3.ParameterName = "@site";
    param3.Value         =cmb_Site.SelectedValue.ToString();
    
    command.Parameters.Add(param1);
    command.Parameters.Add(param2);
    command.Parameters.Add(param3);
