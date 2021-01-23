     string strprovider = @"provider=microsoft.jet.oledb.4.0;data source=C:\Users\farrejos\Documents\inboxV2.mdb;persist security info=false";
            OleDbConnection newConn = new OleDbConnection(strprovider);
            System.Data.DataTable dt = new System.Data.DataTable();
            DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            OleDbDataAdapter dap = new OleDbDataAdapter("Select * from ocr where OCR = " + comboBox2.SelectedText.ToString() + "", newConn);
            if (dap != null)
            {                
                dap.Fill(ds);
            }
            
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                textBox3.Text = myRow[4].ToString();
                textBox4.Text = myRow[6].ToString();
            }
        }
