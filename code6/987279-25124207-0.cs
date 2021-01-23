    private void btnEndSale_Click(object sender, EventArgs e)
    {
        PurchaseTotal();
    }
    private void PurchaseTotal()
    {
        dblGrandTotal = dblSubtotal + dblTaxTotal;
        lbxTally.Items.Add("");
        lbxTally.Items.Add("");
        lbxTally.Items.Add("Subtotal: " + dblSubtotal.ToString("C"));
        lbxTally.Items.Add("Tax Total: " + dblTaxTotal.ToString("C"));
        lbxTally.Items.Add("Grand Total: " + dblGrandTotal.ToString("C"));
    }
