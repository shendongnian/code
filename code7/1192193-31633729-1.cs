ms[i].Message = (string)dr.ItemArray[1];
    MessageInitializer()
    {
        this.ms = new Message[ds.Tables[0].Rows.Count];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            dr = ds.Tables[0].Rows[i];
            ms[i].Code= (string)dr.ItemArray[0];
            ms[i].Message = (string)dr.ItemArray[1];
        }
    }
