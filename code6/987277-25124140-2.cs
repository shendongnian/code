    static void PurchaseTotal(LabelBox lbxTally, ref double dblSubtotal, ref double dblTaxTotal, ref double dblGrandTotal)    
    {
        dblGrandTotal = dblSubtotal + dblTaxTotal;
        lbxTally.Items.Add("");
        lbxTally.Items.Add("");
        lbxTally.Items.Add("Subtotal: " + dblSubtotal.ToString("C"));
        lbxTally.Items.Add("Tax Total: " + dblTaxTotal.ToString("C"));
        lbxTally.Items.Add("Grand Total: " + dblGrandTotal.ToString("C"));
    }
