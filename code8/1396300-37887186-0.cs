    protected void btnDelete_Click(object sender, MenuItemEventArgs e)
    {
        if (e.item.name === "Yes")
        {
            MySQLCommand commad = new MySQLCommand("delete_object");//procedure
            commad.MyParam.AddWithValue("@ob_id", ObjectID);
            commad.myExecuteNonQuery();
        }
    }
