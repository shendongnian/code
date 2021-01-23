    private string QuantityText = string.Empty;
    private void QtyButton_Click(object sender, EventArgs e)
    {
        if (sender is Button) 
        {
          Button theButton = (Button)sender;
          string qtyText = theButton.Content.ToString();
          QuantityText += qtyText;
        }
    }
