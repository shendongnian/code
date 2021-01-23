    {
                NameTableAdapter TA = new  NameTableAdapter();
                NameDataSet rds = new NameDataSet();
                NameDataSet.NameDataTable Rdt = new NameDataSet.NameDataTable();
                TA.Fill(Rdt);
                GridView.DataSource = Rdt;
                GridView.DataBind();
                GridView.Rows[0].Cells[0].Visible = true;
            }
