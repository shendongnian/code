    private void toolStripMenuItem_ClickForm1(object sender, EventArgs e)
    {
        ShowForm1();
    }
        public void ShowForm1()
        {
            try
            {
                if (frm1 == null)
                {
                    frm1 = new Form1();
                    frm1.MdiParent = this;
                }
                else if (frm1.MdiParent == null)
                {
                    frm1 = new Form1();
                    frm1.MdiParent = this;
                }
                frm1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
