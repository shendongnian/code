    void grdTemp_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if(e.Column.Header == "ID") //you can add your check for the column
                  e.Column.Visibility = Visibility.Collapsed;
            }
