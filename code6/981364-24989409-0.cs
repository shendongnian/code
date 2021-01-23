    using System.Drawing;
     
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
     {
      if (e.Item is GridDataItem)
        {
         TableCell celltoVerify1 = dataBoundItem["status"];
           if (celltoVerify1.Text== "REJECTED")
            {
                celltoVerify1.ForeColor =  Color.Red;
                //celltoVerify1.Font.Bold = true;
                //celltoVerify1.BackColor = Color.Yellow;
            }
        }
     }
