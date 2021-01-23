    foreach (GridDataItem item in grdInvoiceItems.Items)
    {
              //object id = (object)item.OwnerTableView.DataKeyValues[item.ItemIndex]["Id"];
              object value = item["Id"].Text;
              id = (item["Id"].FindControl("lblId") as RadTextBox).Text;
              string lineItem = (item["Item"].FindControl("ddlItems") as RadComboBox).Text;
              string description = (item["Description"].FindControl("txtDescription") as RadTextBox).Text;
              double? price = (item["Price"].FindControl("txtPrice") as RadNumericTextBox).Value;
              double? qty = (item["Qty"].FindControl("txtQty") as RadNumericTextBox).Value;
              double? discount = (item["Discount"].FindControl("txtDiscount") as RadNumericTextBox).Value;
              //double tax = double.Parse(lblTaxes.Text);
              //Label amount1 = (item["Amount"].FindControl("lblAmount") as Label);
              //string amount = item["Amount"].Text;
              //Label amount1 = (item.FindControl("lblAmount") as Label);
              double? amounnt = (item["Amount"].FindControl("lblAmount") as RadNumericTextBox).Value;
 
              if (!string.IsNullOrEmpty(lineItem))
              {
                  Invoice.UpdateInvoiceItems(Convert.ToInt32(id), lineItem, description, Convert.ToDouble(price),
                      Convert.ToInt32(qty), Convert.ToDouble(discount), 0, Convert.ToDouble(amounnt));
              }
          }
