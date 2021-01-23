    private bool IsChanging;
    
    private dgv_ThatCausesChanges_CellValueChanged(object sender, EventArgs e)
    {
        this.IsChanging = true;
        try // To make sure that handlers are reinstatiated even on exception thanks @Steve
        {  
         
            // Change other DGVs
        }
        finally
        {    
            this.IsCHanging = false;
        }
    }
    
    private dgv_OtherDGVCellValueChanged(object sender, EventArgs e)
    {
        if (this.IsChanging)
            return;
         
        // Handle changes
    }
