    for (int i = 0; i < Table1.Rows.Count; i++)
    {
         HtmlSelect select = Table1.Rows[i].Cells[0].FindControl(string.Format("selectBoxstatus{0}", i)) as HtmlSelect;
         if(select != null)
             System.Diagnostics.Debug.Write(select.Value);
    }
