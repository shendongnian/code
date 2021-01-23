        private Boolean formCloseFlag = false;
        private void SomeAction()
        {
            formCloseFlag = true;
            DialogResult dlgr = MessageBox.Show(this,
                "message", "title", MessageBoxButtons.YesNo,
                "message", "MessageBoxIcon.Warning);
            if (dlgr == DialogResult.Yes)
            {
                DoStuff();
            }
        }
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formCloseFlag)
            {
                formCloseFlag = false;
                e.Cancel = true;
            }
        }
