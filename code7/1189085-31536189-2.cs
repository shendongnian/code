    private string sel;
    
    protected void DDLReasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        sel = ddlReasons.SelectedValue.ToString();
    }
    
    public static void UpdateSerialReason(int SerNoID, string Reasons)
    {
        JobPieceSerialNo SerNo = new JobPieceSerialNo(SerNoID);
        SerNo.Reason = sel; // Should now be available
        SerNo.Update();
    }
