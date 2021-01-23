    protected override OnLoad(EventArgs e)
    {
        var doc = XDocument.Load("path/to/xml/file");
        foreach(var element in doc.Descendant("PictureBoxes").Elements())
        {
            var pb = new PictureBox();
            pb.Size.Width = Convert.ToInt32(element.Element("SizeWidth").Value));
            // other properties here
            this.Controls.Add(pb);
        }
    }
