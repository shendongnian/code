    private void dg_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
    {
      string str = e.PropertyName;
      int num = int.Parse(e.PropertyName);
      e.Column.Header = "C" + (num + 1).ToString();
      e.Column.ElementStyle = FindResource("BlackCellStyle") as Style;
    }
