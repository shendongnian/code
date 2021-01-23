    if (logoPrvw.Value != null)
        return;
    System.Drawing.Image img = System.Drawing.Image.FromFile(logoPrvw.Value);
    byte[] logoBytes;
    using (MemoryStream ms = new MemoryStream())
    {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        logoBytes = ms.ToArray();
    }
    TemplateData data = new TemplateData(txtSchemeCode.Text, txtVersion.Text, txtComment.Text, txtTemplateId.Text, logoBytes);
    //rest of your code
