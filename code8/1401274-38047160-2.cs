    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        var doc = new XDocument();
        doc.Add(new XElement("PictureBoxes", 
            this.Controls.Where(c => c.GetType() == typeof(PictureBox))
                .Select(pb => new XElement(pb.Name,
                    new XElement("SizeWidth", pb.Size.Width),
                    new XElement("location", pb.Location.X)))));
        doc.Save("path/to/xml/file");
    }
