    public override object Clone()
    {
        ParaGridViewColumncolumn column = (ParaGridViewColumn)base.Clone();
        //Uncomment if you have ParaGridViewCell
        //column.CellTemplate = (ParaGridViewCell)CellTemplate.Clone();
        column.Necessary  = this.Necessary;
        column.ReadOnlyEmpty = this.ReadOnlyEmpty;
        return column;
    }
