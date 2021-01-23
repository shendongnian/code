    public DateTime Date { get; set; }
    public DateTime ChecklistDate { get; set; }
    
    protected override void FillObject(DataRow dr)
    {
    	if (dr["Date"] != DBNull.Value)
    		Date = Convert.ToDateTime(dr["Date"]);
    	if (dr["ChecklistDate"] != DBNull.Value)
    		ChecklistDate = Convert.ToDateTime(dr["ChecklistDate"]);
    }
    
    <asp:BoundField DataField="Date" HeaderText="Service Date" SortExpression="Date"  dataformatstring="{0:dd/MM/yyyy}"></asp:BoundField>
    <asp:BoundField DataField="ChecklistDate" HeaderText="Checklist Date" SortExpression="ChecklistDate"  dataformatstring="{0:dd/MM/yyyy}"></asp:BoundField> 
