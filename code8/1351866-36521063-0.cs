    if (vcon2.State != ConnectionState.Open)
    {
        vcon2.Open();
    }
    vCom.ExecuteNonQuery();
