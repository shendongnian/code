    if (string.IsNullOrEmpty(cboPorts.Text.Trim()))
            {
                MessageBox.Show("Select COM port first.", "Err", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMessage.Focus();
                return;
            }
            
            if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
            {
                MessageBox.Show("Please Enter a Message.", "Err", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtMessage.Focus();
                return;
            }
            SMS sm = new SMS(cboPorts.Text);
            sm.Opens();
            MessageBox.Show(lvNumbers.CheckedItems.Count.ToString());
            foreach (ListViewItem eachItem in lvNumbers.CheckedItems)
                {
                
                    string Selected = eachItem.SubItems[1].Text;                
                    sm.sendSMS(Selected, txtMessage.Text);
                }
            sm.Closes();
            MessageBox.Show("Messages Sent.");
