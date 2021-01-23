    DataTable newDT = new DataTable();
    newDT.Columns.Add("Date", typeof(string));
    newDT.Columns.Add("Titles", typeof(string));
    string pDT = string.Format("{0:dd.MM}", dt.Rows[0]["EventDate"]);
    string titles = dt.Rows(0)("Title") + ",";
    for (x = 1; x <= dt.Rows.Count - 1; x++) {
    	string nD = string.Format("{0:dd.MM}", dt.Rows[0]["EventDate"]);
    	if (pDT != nD) {
    		titles = Strings.Mid(titles, 1, Strings.Len(titles) - 1);
    		newDT.Rows.Add({
    			pDT,
    			string.Join("<br>", titles.Split(",").ToArray)
    		});
    		pDT = string.Format("{0:dd.MM}", dt.Rows(x)("EventDate"));
    		titles = dt.Rows(x)("Title") + ",";
    	} else {
    		titles += dt.Rows(x)("Title") + ",";
    	}
    }
    titles = Strings.Mid(titles, 1, Strings.Len(titles) - 1);
    newDT.Rows.Add({
    	pDT,
    	string.Join("<br>", titles.Split(",").ToArray)
    });
    rptDate.DataSource = newDT;
    rptDate.DataBind();
