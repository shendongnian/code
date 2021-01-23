    private void SaveButton_Click(object sender, EventArgs e)
    {
        MemoryStream fingerprintData = new MemoryStream();
        Template.Serialize(fingerprintData);
        fingerprintData.Position = 0;
        BinaryReader br = new BinaryReader(fingerprintData);
        Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
    
        //Insert the file into database
        SqlConnection cn = new SqlConnection("Data Source=10.115.5.3; Initial Catalog=EnrollmentSampledb;Integrated Security=SSPI;");
        SqlCommand cmd = new SqlCommand("INSERT INTO tblUser VALUES(@ID_NUMBER, @FIRSTNAME, @LASTNAME, @FINGERPRINT, @DATE_ADDED, @DATE_MODIFIED)", cn);
        cmd.Parameters.Add("ID_NUMBER", SqlDbType.NVarChar).Value = tboxIdNum.Text;
        cmd.Parameters.Add("FIRSTNAME", SqlDbType.NVarChar).Value = tboxFname.Text;
        cmd.Parameters.Add("LASTNAME", SqlDbType.NVarChar).Value = tboxLname.Text;
        cmd.Parameters.Add("FINGERPRINT", SqlDbType.Image).Value = bytes;
        cmd.Parameters.Add("DATE_ADDED", SqlDbType.DateTime).Value = DateTime.Now;
        cmd.Parameters.Add("DATE_MODIFIED", SqlDbType.DateTime).Value = DateTime.Now;
    
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
    
        tboxIdNum.Text = "";
        tboxFname.Text = "";
        tboxLname.Text = "";
    }   
