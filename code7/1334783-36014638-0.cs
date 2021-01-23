    private void Do_FillGrid() {            
        try
        {
            Data_Grid1.Columns.Add("Col_xID", "p_ID");
            Data_Grid1.Columns.Add("Col_Unit", "p_Unit");
            Data_Grid1.Columns.Add("Col_Date", "p_Date");
            Data_Grid1.Columns.Add("Col_ValStr", "p_ValStr");
            Data_Grid1.Columns.Add("Col_Status", "p_Status");
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        foreach (SimpleEdnaTag oneTag in MyTags) {
            Data_Grid1.Rows.Add(
                oneTag._id, oneTag._Units, oneTag._PointDate, oneTag._PointValueString, oneTag._PointStatus);
        }
    }
