    ...
    for (int i = 0; i < gvCurrentAgreements.Rows.Count; i++)
    {
        var griddescripton = gvCurrentAgreements.Rows[i].Cells[2].Value.ToString();
        var gridprice = gvCurrentAgreements.Rows[i].Cells[4].Value.ToString();
        var gridquantity = Convert.ToString(gvCurrentAgreements.Rows[i].Cells[3].Value);
        foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
        if (field.Code.Text.Contains("Description"))
        // etc
