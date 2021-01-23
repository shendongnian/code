    //Please call me during Init
    protected void createTheControls() { 
        TableRow tr;
        TableCell td;
        CheckBox cb;
        HiddenField section, sequence;
        foreach (Object item in someList)
        {
            section = new HiddenField();
            section.Value = item.Attributes["ree_sectionnumber"].ToString();
            sequence = new HiddenField;
            sequence.Value = item.Attributes["ree_sequencenumber"].ToString();
            cb = new CheckBox();
            cb.ID = String.Concat("checkbox", (String)sequence.Value);
            if (item.Attributes.Contains("ree_completed"))
                cb.Checked = (bool)item.Attributes["ree_completed"];
                td = new TableCell();
                td.Controls.Add(section);
                td.Controls.Add(sequence);
                td.Controls.Add(cb);
                tr = new TableRow();
                tr.Cells.Add(td);
            }
        }
    protected void readTheControls()
    {
        foreach (TableRow tr in myTable.Rows)
        {
            HiddenField section = (HiddenField)tr.Cells[0].Controls[0];
            HiddenField sequence = (HiddenField)tr.Cells[0].Controls[1];
            CheckBox cb = (CheckBox)tr.Cells[0].Controls[2];
        }
    }
