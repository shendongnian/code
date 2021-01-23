    List<DataGridView> DGVs = new List<DataGridView>();
    foreach (DataTable DT in DS.Tables){
        DataGridView DGV = new DataGridView();
        DGV.DataSource=DT;
        DGVs.Add(DGV);
        //Add code for adding them to the form
    }
