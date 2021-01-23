    private void Button_Click(object sender, RoutedEventArgs e)
    {            
       System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
       if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
       {
          Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
          // sizing of the element.
          dataGrid.Measure(pageSize);
          dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
          Printdlg.PrintVisual(dataGrid, Title);
       }
    }
