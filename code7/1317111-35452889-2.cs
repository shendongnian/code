    private void test_button_Click(object sender, EventArgs e)
    {
        StoreImage(someImageFile);
        using (MemoryStream ms = new MemoryStream(img_byte))
        {
            aPictureBox.Image = Image.FromStream(ms);
        }
    }
