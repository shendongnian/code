        DataSet ds = new DataSet();
        //ds.Tables.Add(dt);
        string sql = String.Format("select * from [ocr] where [ocr].[OCR] = {0}", comboBox2.SelectedText);
        System.Diagnostics.Debug.WriteLine(s);
        OleDbDataAdapter dap = new OleDbDataAdapter(sql, newConn);
