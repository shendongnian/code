    void tprice_TextChanged(object sender, EventArgs e) {
        if (bsave.Click == null)
        {
            bsave.Click += bsave_Click;
        }
        ....
    }
    protected void bsave_Click(object sender, EventArgs e) {
        bsave.Click = null;
    }
