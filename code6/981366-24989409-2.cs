    using System.Drawing;
     
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
     {
      if (e.Item is GridDataItem)
        {
         TableCell celltoVerify1 = dataBoundItem["status"];
         GridDataItem dataBoundItem = e.Item as GridDataItem;
           if (celltoVerify1.Text== "REJECTED")
            {
                celltoVerify1.ForeColor =  Color.Red;/// Only Change Cell Color
                dataBoundItem.ForeColor = Color.Yellow; /// Change the row Color
                //celltoVerify1.Font.Bold = true;
                //celltoVerify1.BackColor = Color.Yellow;
            }
        }
     }
    
