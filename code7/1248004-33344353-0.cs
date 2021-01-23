     //Store what is selected from the Division's ddl
     string areaSelected = ddlArea.Text.ToString();
     //Then
      ID = DBConnect.InsertRecordGetID(comm, sQuery);
        if (ID > 0)
        {
            //complete the Reference Number
            //string divCode;
            //string sSql = 
            //"SELECT TheDivision FROM       dbo.tbl_Incident_Details   //WHERE ID = " + ID;
            //DataTable dt = new DataTable();
            //dt = DBConnect.DataReaderDataTable(sSql);
            //if(dt.Rows.Count > 0)
            //{
            //      divCode = dt.Rows[0][0].ToString();
            //}
            //else
            //{
            //    divCode = "Unavailable";
            //}
            string TheDate = DateTime.Now.Year.ToString();
            string TheYear = TheDate.Substring(2, 2);
            string RefNo = "FAI/" + ID + "/" + areaSelected + "/" + TheYear;
            //The Update and the rest then works neatly and I get a nicely formated string in my db ;-)
