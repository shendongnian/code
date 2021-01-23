       private void button_Click(object sender, RoutedEventArgs e)
        {       
            dataGrid1.SelectAllCells();
            dataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dataGrid1);
            dataGrid1.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            File.AppendAllText("D:\\test.csv", result, UnicodeEncoding.UTF8);
        }
