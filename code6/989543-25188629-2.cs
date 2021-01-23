    DataTable dtTable;
    public DataTable DataTransferTable
    {
    
       get { return dtTable; }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lstTransferView = new ListView();
        DataView dtView = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        dtTable = new DataTable();
        dtTable = dtView.ToTable().Clone();
        DataRow dtRow;
        foreach (ListViewDataItem lstItem in lstView.Items)
        {
             if (((CheckBox)lstItem.FindControl("chkBox")).Checked)
             {               
                 dtRow = (DataRow)dtView.Table.Rows[lstItem.DataItemIndex];                                        
                 dtTable.ImportRow(dtRow);
             }
        }
            
        Server.Transfer("~/SecondPage.aspx");
    }
