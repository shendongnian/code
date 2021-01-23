        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color: #87CEFA";
           
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Mobile = e.Row.Cells[3].Text;
            string securedPhone = Mobile .Remove(6);
           string MobileSecured= securedPhone + "****";
            e.Row.Cells[3].Text = MobileSecured;
        }
    }
