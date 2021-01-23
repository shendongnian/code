    private bool tpriceIsDirty = false;
    void tprice_TextChanged(object sender, EventArgs e) {
        tpriceIsDirty = true;
        // Do work
    }
    protected void bsave_Click(object sender, EventArgs e) {
        if (tpriceIsDirty)
        {
            tpriceIsDirty = false;
            // Do work
        }
    }
