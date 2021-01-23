    using (DataTable dt = new DataTable())
    {
         dt.Load(reader);
         
        if (dt.Rows.Count == 1)
        {
        	defaultComfirm.Show();
        	promotion = false;
        }
        else
        {
            ...
        }
        reader.Close();
    }
