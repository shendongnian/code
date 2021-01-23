            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
      
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e) //This is to allow nubers with one dot as decimal place only in all datagrids
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (((TextBox)sender).Text.Contains(".") & e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
