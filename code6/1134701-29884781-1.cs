        private void Connection()
        {
            //Please use a using statement as below
            using (SqlConnection conn = new SqlConnection("Data Source=PWALTON-ACER;Initial Catalog=pwalton-test;Integrated Security=True"))
            {
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter
                ("SELECT [StandardCode], c.CanStatement, [StandardDetail] FROM [dbo].[StandardCodesAndDetails] s JOIN dbo.CanStatements c ON c.StandardsID=s.ID", conn);
                adapter.Fill(ds);
                lstBoxStandardCodes.DataSource = ds.Tables[0];
                lstBoxStandardCodes.DataTextField = "StandardCode";
                lstBoxStandardCodes.DataBind(); //Don't forget to DataBind()
                lstBoxStandardDetails.DataSource = ds.Tables[0];
                lstBoxStandardDetails.DataTextField = "StandardDetail";
                lstBoxStandardDetails.DataBind(); //This list won't populate if you don't DataBind()
            }
        }
