    private async void YourForm_Load(object sender, EventArgs e)
    {
        using (var c = new HttpClient())
        using (var resp = await c.GetAsync(@"http://uri/to/image.jpg"))
        using (var content = resp.Content)
        using (var s = await content.ReadAsStreamAsync())
        {
            _img = new Bitmap(s);
        }
        YourControl.Refresh();
    }
    private void YourForm_Paint(object sender, PaintEventArgs e)
    {
        if (_img != null)
            DrawToYourControl(_img);
    }
