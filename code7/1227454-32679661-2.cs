    foreach (DataColumn col in PersonTable.Columns)
                {
                    DataGridTemplateColumn dtcol;
    
                    using (StreamReader reader = new StreamReader(("32678595/DataGridTemplateColumn.txt")))
                    {
                        String xamlContent = reader.ReadToEnd();
                        xamlContent = xamlContent.Replace("^colname^", col.ColumnName);
    
                        dtcol = (DataGridTemplateColumn)(System.Windows.Markup.XamlReader.Parse(xamlContent));
                    }
    
                    dtcol.Header = col.ColumnName;
                    MyDataGrid1.Columns.Add(dtcol);
                }
    
                MyDataGrid1.ItemsSource = PersonTable.DefaultView;
