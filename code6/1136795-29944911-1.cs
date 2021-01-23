    public void txt_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOK_Click(sender, e); // or btn.PerformClick();
                    return;               
                }
            }
