    GridView1.Rows.Select(x=> new 
    {
                    Template = row.Cells[0].Text;
                    Cust_Name = row.Cells[1].Text;
                    Invoice_No = int.Parse(row.Cells[2].Text);
                    InvoiceDate = DateTime.ParseExact(row.Cells[3].Text, "d-MMM-yy", CultureInfo.InvariantCulture);
                    nvoiceDate = (row.Cells[3].Text);
                    Sr_No = int.Parse(row.Cells[4].Text);
    }).Distinct();
