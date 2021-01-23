    private void button1_Click(object sender, EventArgs e)
    {
        var cookies = new NameValueCollection();
        for (int tries = 0; tries < 2; tries++)
        {
            using (var response = Builder(_URL, "www.habbo." + _Country, cookies))
            {
                using (var stream = response.GetResponseStream())
                {
                    string contentType = response.ContentType.ToLowerInvariant();
                    if (contentType.StartsWith("text/html"))
                    {
                        var parameters = Parse(stream, response.CharacterSet);
                        cookies.Add(parameters[0], parameters[1]);
                    }
                    if (contentType.StartsWith("image"))
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                        break; // we're done, get out
                    }
                }
            }
        }
    }
