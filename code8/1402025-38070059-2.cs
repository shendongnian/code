    List<DataGridView> DGVs = new List<DataGridView>();
    Point p = new Point(0,0); //Position of the first DGV, choose the one you want
    foreach (DataTable DT in DS.Tables){
        DataGridView DGV = new DataGridView();
        DGV.DataSource=DT;
        DGVs.Add(DGV);
        p.Y += DGV.Height + 10; //Margin that you want
        DGV.Location = p;
        this.Controls.Add(DGV);
        DGV.Show();
    }
