    private void button3_Click(object sender, EventArgs e)
    { 
        if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            textBox1.Text = openFileDialog1.FileName;
            textEditor.Text = File.ReadAllText(textBox1.Text);    
            using (BinaryReader br = new BinaryReader(File.Open(textBox1.Text, FileMode.Open)))
	        {
    	        int pos = 0;
    	        int length = (int)br.BaseStream.Length;
                int numBytesToRead = 1;
	            while (pos < length)
	            {
                    byte[] buffer = br.ReadBytes(numBytesToRead);
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        textEditor.Text += buffer[i].ToString("X2");
                        textEditor.Text += " "; // Will put a space between each hex character
                    }
                    pos += numBytesToRead;
	            }
	        }
        }
    }
