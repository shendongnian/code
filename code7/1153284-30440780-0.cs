    private void TextBox1_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    	{
    		if (e.KeyChar == ".") {
    			e.KeyChar = ",";
    		}
    	}
