    private void FormDialog_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode==Keys.Enter)
                {
                    //set you property
                    this.DialogResult=System.Windows.Forms.DialogResult.OK;
                }
            }
