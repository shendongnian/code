    private void picImage_MouseMove(object sender, MouseEventArgs e)
    {
        Point p = picImage.PointToClient(Cursor.Position);
        Int32 coord = (e.Y + picImage.Padding.Top) * this.picWidth + e.X + picImage.Padding.Left;
        if (e.X < 0 || e.Y < 0 || coord > this.continentGuide.Length)
            return;
        Int32 continent = this.continentGuide[coord];
        if (continent == previousContinent)
            return;
        previousContinent = continent;
        if(this.continents.Length >= continent)
            return;
        this.lblContinent.Text = this.continents[continent];
        this.picImage.Image = GetHighlightPic(continent);
    }
