     private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = await Task.Run(() =>
            {
                using (Image image = Image.FromFile(filepath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, ImageFormat.Png);
                        byte[] imageBytes = ms.ToArray();
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            });
        }
