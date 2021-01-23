    public bool txtBoxValidate(Control txtBoxName, string msg, Control frmName)
        {
            if (String.IsNullOrEmpty(txtBoxName))
            {
                MessageBox.Show(msg, MsgBoxStyle.Exclamation, frmName.Text);
                txtBoxName.Focus();
                 return false;
            }
             return true;
         }
