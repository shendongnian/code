    private void SortDataTable(){
    DataView dv = GetDataTejbl.DefaultView.Sort = "["+comboEdit.Text + "] DESC";
    DataTable SortedDataTable = dv.ToTable();
    if(SortedDataTable!=null){
     gridControl1.DataSource = SortedDataTable;
}
}
