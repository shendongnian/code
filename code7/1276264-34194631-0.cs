     private void FillTable()
            {
                DataColumn c = new DataColumn();
                c.ColumnName = "Col1";
                this.TableResult.Columns.Add(c);
                c = new DataColumn();
                c.ColumnName = "Col2";
                this.TableResult.Columns.Add(c);
                DataRow row1 = this.TableResult.NewRow();
                row1["Col1"] = "Blue";
                row1["Col2"] = "12"; ;
                this.TableResult.Rows.Add(row1);
                DataRow row2 = this.TableResult.NewRow();
                row2["Col1"] = "Red";
                row2["Col2"] = "18";
                this.TableResult.Rows.Add(row2);
                DataRow row3 = this.TableResult.NewRow();
                row3["Col1"] = "Yellow";
                row3["Col2"] = "27";
                this.TableResult.Rows.Add(row3);
                dataGrid1.ItemsSource = this.tableResult.DefaultView;
            }
       
