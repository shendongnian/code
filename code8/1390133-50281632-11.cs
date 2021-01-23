      public  class PrintDG
    {
          public void printDG(DataGrid dataGrid, string title)
        {
     
           PrintDialog printDialog = new PrintDialog();
    if (printDialog.ShowDialog() == true)
                { 
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph(new Run(title));
            p.FontStyle = dataGrid.FontStyle;
            p.FontFamily = dataGrid.FontFamily;
            p.FontSize = 18;
            fd.Blocks.Add(p);
            Table table = new Table();
            TableRowGroup tableRowGroup = new TableRowGroup();
            TableRow r = new TableRow();
            fd.PageWidth = printDialog.PrintableAreaWidth;
            fd.PageHeight = printDialog.PrintableAreaHeight;
            fd.BringIntoView();
            fd.TextAlignment = TextAlignment.Center;
            fd.ColumnWidth = 500;
            table.CellSpacing = 0;
            table.FlowDirection = FlowDirection.RightToLeft;
            var headerList = dataGrid.Columns.Select(e => e.Header.ToString()).ToList();
            headerList.Reverse();
            List<BindingExpression> bindList = new List<BindingExpression>();
            if (dataGrid.ItemsSource != null)
            {
                foreach (object item in dataGrid.ItemsSource)
                {
                    DataGridRow row1 = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(item);
                    if (row1 != null)
                    {
                        foreach (BindingExpression binding in row1.BindingGroup.BindingExpressions)
                        {
                            MessageBox.Show(binding.ToString());
                            bindList.Add(binding);
                        }
                    }
                }
            }
            for (int j = 0; j < headerList.Count; j++)
            {
                r.Cells.Add(new TableCell(new Paragraph(new Run(headerList[j]))));
                r.Cells[j].ColumnSpan = 4;
                r.Cells[j].Padding = new Thickness(4);
                r.Cells[j].BorderBrush = Brushes.Black;
                r.Cells[j].FontWeight = FontWeights.Bold;
                r.Cells[j].Background = Brushes.DarkGray;
                r.Cells[j].Foreground = Brushes.White;
                r.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
            }
            tableRowGroup.Rows.Add(r);
            table.RowGroups.Add(tableRowGroup);
            int count;
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                //if(dataGrid.get)
                dynamic row;
                if (dataGrid.ItemsSource.ToString() == "")
                { row = (BalanceClient)dataGrid.Items.GetItemAt(i); }
                else
                {
                    row = (DataRowView)dataGrid.Items.GetItemAt(i);
                }
                table.BorderBrush = Brushes.Gray;
                table.BorderThickness = new Thickness(1, 1, 0, 0);
                table.FontStyle = dataGrid.FontStyle;
                table.FontFamily = dataGrid.FontFamily;
                table.FontSize = 13;
                tableRowGroup = new TableRowGroup();
                r = new TableRow();
                    for (int j = 0; j < bindList.Count; j++)
                    {
                        r.Cells.Add(new TableCell(new Paragraph(new Run(row.bindList[j].ToString()))));
                        r.Cells[j].ColumnSpan = 4;
                        r.Cells[j].Padding = new Thickness(4);
                        r.Cells[j].BorderBrush = Brushes.DarkGray;
                        //r1.Cells[j].Background = Brushes.White;
                        r.Cells[j].BorderThickness = new Thickness(0, 0, 1, 1);
                    }
                    tableRowGroup.Rows.Add(r);
                    table.RowGroups.Add(tableRowGroup);
                }
                fd.Blocks.Add(table);
                printDialog.PrintDocument(((IDocumentPaginatorSource)fd).DocumentPaginator, "");
            }
    }
         }
