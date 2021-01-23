     protected override void OnFormClosing(FormClosingEventArgs e) {
            
            //Double check if user wants to exit
            var result = MessageBox.Show("Are you sure you want to exit?", "Message",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
                e.Cancel = true;
                base.OnFormClosing(e);
        }
