                String strExtract2012 = "WHERE client.typecode = 'I' AND Policy.UniqAgency IN(65536,65537,65538,65539,65540) AND Line.ExpirationDate < '1/1/2013' " +
                    "ORDER BY polagencycode, polbranch, clientlookup, policynumber, lineeff, linetypecode";
                String strWham = strExtract + strExtract2012;
                System.Data.SqlClient.SqlCommand objCmd = new System.Data.SqlClient.SqlCommand(strWham, objConn);
                objCmd.CommandTimeout = 3000;
                System.Data.SqlClient.SqlDataReader objReader;
                objReader = objCmd.ExecuteReader();
                string path = @"\\filepath\ExpThrough201212.xlsx";
                string blankpath = @"\\filepath\blank.xlsx"; - put this blank xlsx file in the *filepath*
                File.Copy(blankpath, path, true);
                
                
                if (objReader.Read())
                {
                    using (SpreadsheetDocument myDoc = SpreadsheetDocument.Open(path, true))
                    {                      
                        WorkbookPart workbookPart = myDoc.WorkbookPart;
                        
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                        string origninalSheetId = workbookPart.GetIdOfPart(worksheetPart);
                        WorksheetPart replacementPart = workbookPart.AddNewPart<WorksheetPart>();
                        string replacementPartId = workbookPart.GetIdOfPart(replacementPart);
                        OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                        OpenXmlWriter writer = OpenXmlWriter.Create(replacementPart);
                        
                        while (reader.Read())
                        {
                            if (reader.ElementType == typeof(SheetData))
                            {
                                if (reader.IsEndElement)
                                    continue;
                                writer.WriteStartElement(new SheetData());
                                Row rr = new Row();
                                writer.WriteStartElement(rr);
                                //Add Header          
                                for (int count = 0; count < objReader.FieldCount; count++)
                                {
                                    String FieldName = objReader.GetName(count);
                                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(objReader.GetName(count));
                                    //headerRow.AppendChild(cell);
                                    writer.WriteElement(cell);
                                }
                                writer.WriteEndElement();
                                //writer.WriteEndElement();
                                //sheetData.AppendChild(headerRow);
                                while (objReader.Read())
                                {
                                    //DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                                    Row r = new Row();
                                    writer.WriteStartElement(r);
                                    
                                    for (int col = 0; col < objReader.FieldCount; col++)
                                    {
                                        String FieldValue = objReader.GetValue(col).ToString();
                                        //columns.Add(FieldValue);
                                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                        cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(FieldValue);
                                        //newRow.AppendChild(cell);
                                        writer.WriteElement(cell);
                                    }
                                    //.AppendChild(newRow);
                                    writer.WriteEndElement();                                    
                                }
                                writer.WriteEndElement();
                            }
                            else
                            {
                                if (reader.IsStartElement)
                                {
                                    writer.WriteStartElement(reader);
                                }
                                else if (reader.IsEndElement)
                                {
                                    writer.WriteEndElement();
                                }
                            }
                        }
                        reader.Close();
                        writer.Close();
                        Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Id.Value.Equals(origninalSheetId)).First();
                        sheet.Id.Value = replacementPartId;
                        workbookPart.DeletePart(worksheetPart);
                    }
                }
                objReader.Close();
