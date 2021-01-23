    private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytes = HexToBytes(textBox1.Text);
            var x = Encoding.UTF8.GetString(bytes).Replace("\0", " ");
            textBox1.Text = x;
        }
    public static byte[] HexToBytes(string hex)
        {
            hex = hex.Trim();
            byte[] bytes = new byte[hex.Length / 2];
            for (int index = 0; index < bytes.Length; index++)
            {
                bytes[index] = byte.Parse(hex.Substring(index * 2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }
