    void btn_Click(object sender, EventArgs e) {
    	StringBuilder sb = new StringBuilder();
    	richTextBox.Text = "asdf";
    	for (int i = 24; i <= 100; i++) {
    		using (Font f = new Font(SystemFonts.DefaultFont.FontFamily, 1f * i / 4)) {
    			richTextBox.SelectAll();
    			richTextBox.SelectionFont = f;
    			richTextBox.Font = f;
    			sb.AppendLine(f.Size + "\t" + richTextBox.SelectionFont.Size + "\t" + Math.Round(f.Size - richTextBox.SelectionFont.Size, 3));
    		}
    	}
    }
