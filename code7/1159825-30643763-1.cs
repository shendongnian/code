    byte[] logoBytes;
    if (logoPrvw.Value != null)
    {
        ...
        // Code that assigns a value to logoBytes
    }
    else
    {
        logoBytes = new byte[0];
    }
    TemplateData data = new TemplateData(..., logoBytes);
