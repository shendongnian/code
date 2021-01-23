    private void btnBold_Click(object sender, EventArgs e)
        {
            FontStyle style = tbMessage.SelectionFont.Style;
            if (tbMessage.SelectionFont.Bold)
            {
                style = style & ~FontStyle.Bold;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Regular);
            }
            else
            {
                style = style | FontStyle.Bold;
                btnBold.Font = new Font(btnBold.Font, FontStyle.Bold);
            }
            tbMessage.SelectionFont = new Font(tbMessage.SelectionFont, style);
            tbMessage.Focus();
        }
