        private void cb_oqty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var proprice = Convert.ToSingle(txt_oprice.Text);
            var quantity = Convert.ToSingle(cb_oqty.SelectedItem);
            var orderprice = proprice * quantity;
            txt_orderprice.Text = orderprice.ToString();
            // this does not do what you think it does. You can remove this line.
            txt_orderprice.Update();
        }
