    using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(YourExcelfileName, true))
            {
                // Create reference of main Workbook part, which contains all reference.
                WorkbookPart objworkbook = myDoc.WorkbookPart;
 
                // pick up first worksheet
                WorksheetPart objworksheet = objworkbook.WorksheetParts.First();
 
                // will be used in end while creating sheet data
                string objorigninalSheetId = objworkbook.GetIdOfPart(objworksheet);
                WorksheetPart objreplacementPart = objworkbook.AddNewPart<WorksheetPart>();
                string objreplacementPartId = objworkbook.GetIdOfPart(objreplacementPart);
                Sheets sheets = objworkbook.Workbook.Sheets;
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(objreplacementPart), SheetId = 2, Name = "Sheet" };
                sheets.Append(sheet);
 
                // Create object reader to read from excel file.
                OpenXmlReader objreader = OpenXmlReader.Create(objworksheet);
 
                // create writer object to write in excel sheet.
                OpenXmlWriter objOpenXmwriter = OpenXmlWriter.Create(objreplacementPart);
 
                objOpenXmwriter.WriteStartElement(new Worksheet());
                objOpenXmwriter.WriteStartElement(new SheetData());
                while (objreader.Read())
                {
                //read the context of original sheetdata.
                //then put all data to new sheetdata by openxmlwriter
                    
                }
                
                // this is for Sheetdata
                objOpenXmwriter.WriteEndElement();
                
                //* after Sheetdata you can merge cells by openxmlwriter like that:    
                objOpenXmwriter.WriteStartElement(new MergeCells());
                objOpenXmwriter.WriteElement(new MergeCell() { Reference = "P1:Q1" });
                objOpenXmwriter.WriteElement(new MergeCell() { Reference = "R1:S1" });
                objOpenXmwriter.WriteEndElement();
                // this is for Worksheet
                objOpenXmwriter.WriteEndElement();
                //close all objects
                objreader.Close();
                objOpenXmwriter.Close();
 
                Sheet sheetreplace = objworkbook.Workbook.Descendants<Sheet>().Where(s => s.Id.Value.Equals(objorigninalSheetId)).First();
                sheetreplace.Id.Value = objreplacementPartId;
                objworkbook.DeletePart(objworksheet);
 
            }
 
