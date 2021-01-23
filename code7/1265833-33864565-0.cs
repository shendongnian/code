    Decimal d;
    if (Decimal.TryParse(txtlicensenumber.Text, out d))
    {
      DataTable dd = dc.GetMaxDeathNo(d);
      if (dd.Rows.Count > 0)
      {
          txtdeathaccidentno.Text = dd.Rows[0]["DeathNumber"].ToString();
      }
    }
