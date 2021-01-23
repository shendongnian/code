    StreamWriter sw = null;
    string Name, Company,  Date;   
    JobName = TYest + "_" + System.DateTime.Now;
    JobName = JobName.Replace(":", "").Replace("/", "").Replace(" ", "");
    FileName = @"C:\" + JobName + ".txt";
    try
    {
     foreach (RepeaterItem rpItems in rpGetData.Items)
     {
         RadioButtonList rbYesNo = (RadioButtonList)rpItems.FindControl("rbBadge");
          if (rbYesNo.SelectedItem.Text == "Yes")
           {
               if (null == sw)
                   sw = new StreamWriter(FileName, false, Encoding.GetEncoding(1250));
               Label rName = (Label)rpItems.FindControl("lblName");
               Label rCompany = (Label)rpItems.FindControl("lblCompany");
               Label rFacilityName = (Label)rpItems.FindControl("lblFacility_Hidden");
               Name = rName.Text;
               Company = rCompany.Text;
               Date = System.DateTime.Now.ToString("MM/dd/yyyy");
               sw.WriteLine("Name," + Name);
               sw.WriteLine("Company," + Company);
               sw.WriteLine("Date," + Date);
               sw.WriteLine("*PRINTLABEL");
      }
    }
    finally
    {
        if (null != sw)
        {
            sw.Flush();
            sw.Dispose();
        }
    }
