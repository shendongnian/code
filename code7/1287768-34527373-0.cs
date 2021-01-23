    DataTable dtExcel = new DataTable();
    dtExcel.Clear();
    if (dtExcel.Rows.Count > 0) //Here's the change
    {
      Hid_Mode.Value = "M";
      hid_mkey.Value = dtExcel.Rows[0]["Mkey"].ToString();
    }
    else
    {
      Hid_Mode.Value = "A";
      hid_mkey.Value = "0";
    }
