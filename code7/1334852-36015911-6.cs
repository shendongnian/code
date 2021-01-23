    gridControl1.BeginUpdate();
            try
            {
                gridView1.Columns.Clear();
                gridControl1.DataSource = null;
                gridControl1.DataSource = <newDataSource>;
            }
            finally
            {
                gridControl1.EndUpdate();
            }
