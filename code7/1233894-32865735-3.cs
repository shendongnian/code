    static void AddDataToTable(string filename)
    {
        using (WordprocessingDocument wordDoc =
                WordprocessingDocument.Open(filename, true))
        {
            var body = wordDoc.MainDocumentPart.Document.Body;
            var paras = body.Elements<TableCell>();
            TableCell cell = body.Descendants<TableCell>().ElementAt(0);
            cell.RemoveAllChildren<Paragraph>();
            cell.Append(new Paragraph(new Run(new Text(dr["NAME"].ToString()))));
            if (cell.TableCellProperties != null && cell.TableCellProperties.TableCellMargin != null)
            {
                cell.TableCellProperties.TableCellMargin.BottomMargin = new BottomMargin() { Width = "0" };
                cell.TableCellProperties.TableCellMargin.TopMargin = new TopMargin() { Width = "0" };
            }
            wordDoc.Close(); // close the template file
        }
    }
