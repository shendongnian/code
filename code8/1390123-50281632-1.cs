      public  class PrintDG
    {
        public void printDG(DataGrid dataGrid,  string title)
        {
            PrintDialog printDialog = new PrintDialog();
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph(new Run(title));
            p.FontStyle = dataGrid.FontStyle;
            p.FontFamily = dataGrid.FontFamily;
            p.FontSize = 18;
            fd.Blocks.Add(p);
            Table table = new Table();
            TableRowGroup tableRowGroup = new TableRowGroup();
            TableRow r1 = new TableRow();
            fd.PageWidth = printDialog.PrintableAreaWidth;
            fd.PageHeight = printDialog.PrintableAreaHeight;
            fd.BringIntoView();
            fd.TextAlignment = TextAlignment.Center;
            fd.ColumnWidth = 500;
            table.CellSpacing = 0;
            table.FlowDirection = FlowDirection.RightToLeft;
            var headerList = dataGrid.Columns.Select(e => e.Header.ToString()).ToList();
            headerList.Reverse();
            for (int j = 0; j < headerList.Count; j++)
            {
                r1.Cells.Add(new TableCell(new Paragraph(new Run(headerList[j]))));
                r1.Cells[j].ColumnSpan = 4;
                r1.Cells[j].Padding = new Thickness(4);
                r1.Cells[j].BorderBrush = Brushes.Black;
                r1.Cells[j].FontWeight = FontWeights.Bold;
                r1.Cells[j].Background = Brushes.DarkGray;
                r1.Cells[j].Foreground = Brushes.White;
                r1.Cells[j].BorderThickness = new Thickness( 1,1,1,1);    
            }
            tableRowGroup.Rows.Add(r1);
            table.RowGroups.Add(tableRowGroup);
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                DataRowView row = (DataRowView)dataGrid.Items.GetItemAt(i);
                table.BorderBrush = Brushes.Gray;
                table.BorderThickness = new Thickness(1, 1, 0, 0);
                table.FontStyle = dataGrid.FontStyle;
                table.FontFamily = dataGrid.FontFamily;
                table.FontSize = 13;
                tableRowGroup = new TableRowGroup();
                r1 = new TableRow();
                for (int j = 0; j < row.Row.ItemArray.Count(); j++)
                {
                    r1.Cells.Add(new TableCell(new Paragraph(new Run(row.Row.ItemArray[j].ToString()))));
                    r1.Cells[j].ColumnSpan = 4;
                    r1.Cells[j].Padding = new Thickness(4);
                    r1.Cells[j].BorderBrush = Brushes.DarkGray;
                    //r1.Cells[j].Background = Brushes.White;
                    r1.Cells[j].BorderThickness = new Thickness(0, 0, 1, 1);
                }
                tableRowGroup.Rows.Add(r1);
                table.RowGroups.Add(tableRowGroup);
            }
            fd.Blocks.Add(table);
            printDialog.PrintDocument(((IDocumentPaginatorSource)fd).DocumentPaginator, "");
        }
    }
