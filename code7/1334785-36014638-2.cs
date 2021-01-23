    private void Do_FillGrid() {
        DataGridViewColumnCollection theCols = Data_Grid1.Columns;
        try
        {
            theCols.Add("Col_xID", "p_ID");
            theCols.Add("Col_Unit", "p_Unit");
            theCols.Add("Col_Date", "p_Date");
            theCols.Add("Col_ValStr", "p_ValStr");
            theCols.Add("Col_Status", "p_Status");
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        foreach (SimpleEdnaTag oneTag in MyTags) {
            Data_Grid1.Rows.Add(
                oneTag._id, oneTag._Units, oneTag._PointDate, oneTag._PointValueString, oneTag._PointStatus);
        }
    }
