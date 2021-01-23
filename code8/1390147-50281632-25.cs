c#
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Media;
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
                var headerList = dataGrid.Columns.Select(e => e.Header.ToString()).ToList();
                List<dynamic> bindList = new List<dynamic>();
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
                    var binding = (dataGrid.Columns[j] as DataGridBoundColumn).Binding as Binding;
                    bindList.Add(binding.Path.Path);
                }
                tableRowGroup.Rows.Add(r);
                table.RowGroups.Add(tableRowGroup);
                for (int i = 0; i < dataGrid.Items.Count; i++)
                {
                    dynamic row;
                    if (dataGrid.ItemsSource.ToString().ToLower() == "system.data.linqdataview")
                    { row = (DataRowView)dataGrid.Items.GetItemAt(i); }
                    else
                    {
                        row = (BalanceClient)dataGrid.Items.GetItemAt(i);
                    }
    
                    table.BorderBrush = Brushes.Gray;
                    table.BorderThickness = new Thickness(1, 1, 0, 0);
                    table.FontStyle = dataGrid.FontStyle;
                    table.FontFamily = dataGrid.FontFamily;
                    table.FontSize = 13;
                    tableRowGroup = new TableRowGroup();
                    r = new TableRow();
                    for (int j = 0; j < row.Row.ItemArray.Count(); j++)
                    {
                        if (dataGrid.ItemsSource.ToString().ToLower() == "system.data.linqdataview")
                        {
                            r.Cells.Add(new TableCell(new Paragraph(new Run(row.Row.ItemArray[j].ToString()))));
                        }
                        else
                        {
                            r.Cells.Add(new TableCell(new Paragraph(new Run(row.GetType().GetProperty(bindList[j]).GetValue(row, null)))));
                        }
                        r.Cells[j].ColumnSpan = 4;
                        r.Cells[j].Padding = new Thickness(4);
                        r.Cells[j].BorderBrush = Brushes.DarkGray;
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
Step2:  Then go to print button click event and create object of PrintDG class then call printDG pass to It two parameters datagridname and title.  
Like :  
c#
    private void print_button_Click(object sender, RoutedEventArgs e)
    {
        PrintDG print = new PrintDG();
        print.printDG(datagridName, "Title");
    }
If any error occurs during execution tell me and I will solve It.This is running code only, you need copy and paste.  
Edited:  
I declared row as dynamic. The dynamic keyword decides at run time which type to instantiate, either DataTable or another.
