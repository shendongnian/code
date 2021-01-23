    [Browsable(false)]
    public bool SelectedOneOrMore
    {
        get
        {
            return Rows.GetFirstRow(DataGridViewElementStates.Selected) != -1;
        }
    }
