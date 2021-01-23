        if (rowCount == 0)
        {
             rowIndividuals = new HtmlTableRow("th");   
        }
        else
        {
            rowIndividuals = new HtmlTableRow();
        }  
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.FirstName});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Surname});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.MiddleName});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.DateOfBirth});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Gender});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Address1});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Address2});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Address3});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Address4});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.City});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.PostalCode});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.Country});
        rowIndividuals.Cells.Add(new HtmlTableCell {InnerText = invalidIndividual.NationalID});
        tableIndividuals.Rows.Add(rowIndividuals);
        rowCount++;
    }
