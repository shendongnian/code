    private void btnTestAll_Click(object sender, EventArgs e)
    {
        dt = new System.Data.DataTable();
        string correct = "Brokers México, Intermediario de Aseguro,S.A.";
        string broken = "Brokers MÃ©xico, Intermediario de Aseguro,S.A."; // Get text from database
        dt.Columns.Add("SourceEncoding", typeof(string));
        dt.Columns.Add("TargetEncoding", typeof(string));
        dt.Columns.Add("Result", typeof(string));
        dt.Columns.Add("SourceEncodingName", typeof(string));
        dt.Columns.Add("TargetEncodingName", typeof(string));
        System.Text.EncodingInfo[] encs = System.Text.Encoding.GetEncodings();
        
        for (int i = 0; i < encs.Length; ++i)
        {
            for (int j = 0; j < encs.Length; ++j)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["SourceEncoding"] = encs[i].CodePage;
                dr["TargetEncoding"] = encs[j].CodePage;
                System.Text.Encoding enci = System.Text.Encoding.GetEncoding(encs[i].CodePage);
                System.Text.Encoding encj = System.Text.Encoding.GetEncoding(encs[j].CodePage);
                byte[] encoded = enci.GetBytes(broken);
                string corrected = encj.GetString(encoded);
                dr["Result"] = corrected;
                dr["SourceEncodingName"] = enci.BodyName;
                dr["TargetEncodingName"] = encj.BodyName;
                if (StringComparer.InvariantCultureIgnoreCase.Equals(correct, corrected))
                    dt.Rows.Add(dr);
            }
        }
        this.dataGridView1.DataSource = dt;
    }
