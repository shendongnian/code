    private void FormDialog_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode==Keys.Enter)
                {
                    //set your property
                    this.DialogResult=System.Windows.Forms.DialogResult.OK;
                }
            }
