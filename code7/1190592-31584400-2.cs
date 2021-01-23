    InsideDB = dr["Inside"].ToString();
    Inside.Enabled = true;
    if (!string.IsNullOrEmpty(InsideDB.ToString()))
    {
      Inside.SelectedValue = InsideDB.ToString();
      Inside.Enabled = false;
    }
