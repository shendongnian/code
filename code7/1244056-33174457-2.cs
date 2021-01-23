    var itemsTobeSaved = rpGetData.Items
        Where(ri => ((RadioButtonList)ri.FindControl("rbBadge")).SelectedItem.Text == "Yes");
    if (itemsTobeSaved.Any()) {
        string path = @"C:\" + FileName;
        using (var sw = new StreamWriter(path, false, Encoding.GetEncoding(1250))) {
            foreach (RepeaterItem rpItems in itemsTobeSaved) {
                Label rName = (Label)rpItems.FindControl("lblName");
                Label rCompany = (Label)rpItems.FindControl("lblCompany");
                Label rFacilityName = (Label)rpItems.FindControl("lblFacility_Hidden");
                Name = rName.Text;
                Company = rCompany.Text;
                Date = System.DateTime.Now.ToString("MM/dd/yyyy");
                sw.WriteLine("Name," + Name);
                sw.WriteLine("Company," + Company);
                sw.WriteLine("Date," + Date);
                sw.WriteLine("*PRINTLABEL");
            }
        } // Flushes, Closes und Disposes the stream automatically.
    }
