    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=" + "Application.StartupPath" + "\\GlennTeoDB.mdf; Integrated Security=True;Connect Timeout=30");
    con.Open();
    //get a count records with your index number
    SqlCommand validate = new SqlCommand(string.Format("SELECT count IndexNumber FROM GlennTeoStudents WHERE IndexNumber = {0}", numIN.Value), con);
    int count = (Int32)validate.ExecuteScalar();
    if (count == 0)
    {
        //insert your unqiue index number into a new row
        SqlCommand cmd = new SqlCommand(@"INSERT INTO GlennTeoStudents (IndexNumber,Name,Age,HandphoneNumber,GPA) VALUES ('" + numIN.Value + "','" + txtName.Text + "','" + txtAge.Text + "','" + txtHP.Text + "','" + numGPA.Value + "')", con);
        cmd.ExecuteNonQuery();               
    }
    else
    {
        //don't insert it, do something else like return an error
    }
    con.Close();
