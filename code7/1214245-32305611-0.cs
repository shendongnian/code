            string sUserName ="joe";
            string Value ="4";
            string sProcessStart = "28-08-2015 12:12:26 AM";
            string sProcessEnd = "30-08-2015 12:29:26 PM";
            DataTable dtDLCD = new DataTable();
            DataColumn dtcolumn = new DataColumn("UserName");
            dtcolumn.DefaultValue = "joe";
            dtDLCD.Columns.Add(dtcolumn);
            DataColumn dtcolumn1 = new DataColumn("Value");
            dtcolumn1.DefaultValue = "4";
            dtDLCD.Columns.Add(dtcolumn1);
            DataColumn dtcolumn3 = new DataColumn("StartDate",typeof(DateTime));
            dtcolumn3.DefaultValue = "28-08-2015 12:12:26 AM";
            dtDLCD.Columns.Add(dtcolumn3);
            DataColumn dtcolumn4 = new DataColumn("EndDate", typeof(DateTime));
            dtcolumn4.DefaultValue = "30-08-2015 12:29:26 PM";
            dtDLCD.Columns.Add(dtcolumn4);
            DataRow drow = dtDLCD.NewRow();
            dtDLCD.Rows.Add(drow);
            DataRow[] drDocDetails = dtDLCD.Select("UserName = '" + sUserName + 
                                                   "' AND Value = '" + Value + 
                                                   "' AND StartDate = '" + Convert.ToDateTime(sProcessStart).ToString("yyyy-MM-dd hh:mm:ss tt") +
                                                   "' AND EndDate = '" + Convert.ToDateTime(sProcessEnd).ToString("yyyy-MM-dd hh:mm:ss tt") + "'");
            int count = drDocDetails.Count();
