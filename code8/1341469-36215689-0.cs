    public void BindDatatable()
    {
    DataSet ds = new DataSet();
    DataRow dr;
    DataColumn SR_NO;
    DataColumn PARTY_NAME;
    DataColumn FLAT_NO;
    DataColumn LEASE_NUM;
    DataColumn ACTION;
    DataColumn NO_OF_DAYS;
    DataColumn REMARKS;
    DtCombo = new DataTable();
    SR_NO = new DataColumn("SR_NO", typeof(Int32));
    PARTY_NAME = new DataColumn("PARTY_NAME", typeof(String));
    FLAT_NO = new DataColumn("FLAT_NO", typeof(Int32));
    LEASE_NUM = new DataColumn("LEASE_NUM", typeof(Int32));
    ACTION = new DataColumn("ACTION", typeof(String));
    NO_OF_DAYS = new DataColumn("NO_OF_DAYS", typeof(Int32));
    REMARKS = new DataColumn("REMARKS", typeof(String));
    DtCombo.Columns.Add(SR_NO);
    DtCombo.Columns.Add(PARTY_NAME);
    DtCombo.Columns.Add(FLAT_NO);
    DtCombo.Columns.Add(LEASE_NUM);
    DtCombo.Columns.Add(ACTION);
    DtCombo.Columns.Add(NO_OF_DAYS);
    DtCombo.Columns.Add(REMARKS);
    var row = DtCombo.NewRow();
    row["SR_NO"] = 1;
    DtCombo.Rows.Add(row);
}
