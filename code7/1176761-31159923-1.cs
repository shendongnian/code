            string colname = ListBox1.SelectedItem.Text;
            string value = textBox1.Text;
            if (colname != null && dt.Columns[colname] != null)
            {
                if ("Byte,Decimal,Double,Int16,Int32,Int64,SByte,Single,UInt16,UInt32,UInt64,".Contains(dt.Columns[colname].DataType.Name + ","))
                {
                    dv.RowFilter = colname + "=" + value;
                }
                else if (dt.Columns[colname].DataType == typeof(string))
                {
                    dv.RowFilter = string.Format(colname + " LIKE '%{0}%'", value);
                }
                else if (dt.Columns[colname].DataType == typeof(DateTime))
                {
                    dv.RowFilter = colname + " = #" + value + "#";
                }
            }
