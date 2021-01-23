    private bool IsChanging;
    
    private dgv_ThatCausesChanges_CellValueChanged(object sender, EventArgs e)
    {
        this.IsChanging = true;
         
        // Change other DGVs
    
        this.IsCHanging = false;
    }
    
    private dgv_OtherDGVCellValueChanged(object sender, EventArgs e)
    {
        if (this.IsChanging)
            return;
         
        // Handle changes
    }
