            dataGrid1.TableStyles.Clear();
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = table1.TableName;
            foreach (DataColumn item in table1.Columns)
            {
                DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                tbcName.Width = 80;                
                tbcName.MappingName = item.ColumnName;
                tbcName.HeaderText = item.ColumnName;
                tableStyle.GridColumnStyles.Add(tbcName);
            }
            dataGrid1.TableStyles.Add(tableStyle);
