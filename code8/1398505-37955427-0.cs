    var toRemove = new List<DataRow>();
    foreach (DataRow row in dt.Rows)
    {
        //call search function to look for keyword
        List<int> myPages = new List<int>();
        string fileName = row["linkToPublicationPDF"].ToString();
        myPages = ReadPdfFile(fileName, safeKeyword);
        if (myPages.Count > 0)
        {
            string pagelist = "";
            foreach (int page in myPages)
            {
                pagelist = pagelist + page + "  ";
            }
                row["Pages"] = pagelist;
            }
            else
            {
                //remove/delete the row from the datatable if "myPages.Count" is 0
                toRemove.Add(row);
            }
        }
    foreach (DataRow row toRemove.Add)
    {
        dt.Rows.Remove(row);
    }
