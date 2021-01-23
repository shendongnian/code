    String strWham = strExtract + strExtract2012;
    System.Data.SqlClient.SqlCommand objCmd = new System.Data.SqlClient.SqlCommand(strWham, objConn);
    objCmd.CommandTimeout = 3000;
    System.Data.SqlClient.SqlDataReader objReader;
    objReader = objCmd.ExecuteReader();
    string path = @"\\wsi\userdata\pterrazas\AccountingReports\ExpThrough201212.xlsx";
    using (SpreadsheetDocument myDoc = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
    {
        List<OpenXmlAttribute> xmlAttributes;
        OpenXmlWriter writer;
        //add a workbookpart manually
        myDoc.AddWorkbookPart();
        WorksheetPart worksheetpart = myDoc.WorkbookPart.AddNewPart<WorksheetPart>();
        //create an XML writer for the worksheetpart
        writer = OpenXmlWriter.Create(worksheetpart);
        writer.WriteStartElement(new Worksheet());
        writer.WriteStartElement(new SheetData());
        int rowNumber = 1;
        while (objReader.Read())
        {
            xmlAttributes = new List<OpenXmlAttribute>();
            // this is the row index
            xmlAttributes.Add(new OpenXmlAttribute("r", null, rowNumber.ToString()));
            //write the row start element with the attributes added above
            writer.WriteStartElement(new Row(), xmlAttributes);
            for (int columnNumber = 1; columnNumber < objReader.FieldCount; columnNumber++)
            {
                //reset the attributes
                xmlAttributes = new List<OpenXmlAttribute>();
                // this is the data type ("t"), with CellValues.String ("str")
                // you might need to change this depending on your source data
                // you might also consider using the Shared Strings table instead
                xmlAttributes.Add(new OpenXmlAttribute("t", null, "str"));
                //add the cell reference (A1, B1, A2... etc)
                xmlAttributes.Add(new OpenXmlAttribute("r", null, GetExcelColumnName(rowNumber, columnNumber)));
                //write the start of the cell element with the type and cell reference attributes
                writer.WriteStartElement(new Cell(), xmlAttributes);
                //write the cell value
                writer.WriteElement(new CellValue(objReader[columnNumber].ToString()));
                //write the cell end element
                writer.WriteEndElement();
            }
            //write the row end element
            writer.WriteEndElement();
            
            rowNumber++;
        }
        //write the sheetdata end element
        writer.WriteEndElement();
        //write the worksheet end element
        writer.WriteEndElement();
        writer.Close();
        //create a writer for the workbookpart
        writer = OpenXmlWriter.Create(myDoc.WorkbookPart);
        //write the start element of a workbook to the workbook part
        writer.WriteStartElement(new Workbook());
        //write the start element of a sheets item to the workbook part
        writer.WriteStartElement(new Sheets());
        //write the whole element of a sheet to the workbook part
        //note we link it to the id of the worksheetpart populated above
        writer.WriteElement(new Sheet()
        {
            Name = "Sheet1",
            SheetId = 1,
            Id = myDoc.WorkbookPart.GetIdOfPart(worksheetpart)
        });
        //write the sheets end element
        writer.WriteEndElement();
        //write the workbook end element
        writer.WriteEndElement();
        writer.Close();
        myDoc.Close();
    }
    objConn.Close();
