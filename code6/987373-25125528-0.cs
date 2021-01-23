    private void button3_Click(object sender, EventArgs e)
    {
        schema s1 = new schema(readedImage);
        if(s1.ShowDialog() == DialogResult.OK)
        {
            if(s1.imgToReturn != null)
            {
                readedImage = s1.imgToReturn;
                s1.imgToReturn = null;
            }
            s1.Dispose();
        }
    }
