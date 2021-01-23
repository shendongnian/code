    public void AddornCLs(Chart chart, Axis axis, Image template, Font font, Color color)
    {
        Rectangle rect = new Rectangle(Point.Empty, template.Size);
        TextFormatFlags format = TextFormatFlags.HorizontalCenter 
                               | TextFormatFlags.VerticalCenter;
        foreach(CustomLabel cl in axis.CustomLabels)
        {
            string text = cl.Text;
            if (text == "") text = cl.Tag.ToString();
            cl.Text = "";
            if (cl.Name == "") cl.Name = axis.CustomLabels.IndexOf(cl).ToString("CL000");
            Image img = (Image)template.Clone();
            using (Graphics G = Graphics.FromImage(img))
                TextRenderer.DrawText(G, text, font, rect, color, format);
            chart.Images.Add(new NamedImage(cl.Name, img));
            cl.Image = cl.Name;
        }
    }
