            DialogResult result;
            do
            {
                result = MessageBox.Show("This is a special stock item.\r\nDo you want to add it to the list?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            } while (result == DialogResult.Cancel);
            if (result == DialogResult.Yes)
            {
                // yes
            }
            else
            {
                // no
            }
