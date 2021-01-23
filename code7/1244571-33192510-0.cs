    private async void YourForm_Paint(object sender, PaintEventArgs e)
    {
        if (_img == null)
        {
            using (var c = new HttpClient())
            using (var resp = await c.GetAsync(@"http://uri/to/image.jpg"))
            using (var content = resp.Content)
            {
                var s = await content.ReadAsStreamAsync();
                _img = new Bitmap(s);
            }
        }
        DoSomethingWith(_img);
    }
