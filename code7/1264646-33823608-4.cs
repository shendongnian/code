        private void button1_Click(object sender, EventArgs e)
        {
            string lowitem = "low item";
            string highitem = "high item";
            if (Convert.ToInt32(txtbxquantity.Text) <= 5)
                txtbxhighlowitem.Text = lowitem;
            else
                txtbxhighlowitem.Text = highitem;
        }
    
