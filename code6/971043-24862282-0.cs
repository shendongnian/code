    private void Form1_Load(object sender, EventArgs e)
        {
            int iCol;
            pDataTable.Columns.Add("Dosage", typeof(int));
            pDataTable.Columns.Add("Drug", typeof(string));
            pDataTable.Columns.Add("Patient", typeof(string));
            pDataTable.Columns.Add("Date", typeof(DateTime));
            pDataTable.Rows.Add(25, "Indocin", "David", DateTime.Now);
            pDataTable.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            pDataTable.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            pDataTable.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            pDataTable.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            this.cfg.Clear(C1.Win.C1FlexGrid.ClearFlags.UserData);
            foreach (DataColumn dCol in pDataTable.Columns)
            {
                cfg.Cols.Count += 1;
                iCol = cfg.Cols.Count - cfg.Cols.Fixed;
                cfg.Cols[iCol].Name = dCol.ColumnName;
                cfg.Cols[iCol].Caption = dCol.ColumnName;
                cfg.Cols[iCol].DataType = dCol.DataType;
                switch (dCol.DataType.ToString())
                {
                    case "System.DateTime":
                        {
                            cfg.Cols[iCol].Format = "dd-MMM-yyyy";
                            break;
                        }
                    case "System.Decimal":
                        {
                            cfg.Cols[iCol].Format = "N3";
                            break;
                        }
                    default:
                        break;
                }
            }
            cfg.DataSource = pDataTable.Copy();
        } 
