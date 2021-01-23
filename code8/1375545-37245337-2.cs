            private void txtOther_Click(object sender, EventArgs e)
        {
            foreach (Control c in grpMaterialOptions.Controls)
            {
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                }
            }
        }
