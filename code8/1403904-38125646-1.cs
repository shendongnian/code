                this.RunWithDrawingSuspended(() =>
            {
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.ColumnStyles.Clear();
                foreach (DataRow r in DT.Rows)
                {
                    UcColor button = new UcColor(r);
                    tableLayoutPanel1.Controls.Add(button);//, colNumNew, rowNum);
                }
                this.Controls.Add(tableLayoutPanel1);
            });
