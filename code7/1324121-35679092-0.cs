    For e.g
    foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text == "")
                    {
                        DialogResult x = new DialogResult();
                        x = MessageBox.Show("TextBox cannot be Empty");
                        if (x == DialogResult.OK)
                            txtCCode1.Focus();
                            break;
                    }
