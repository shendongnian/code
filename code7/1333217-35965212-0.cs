    byte[] GetMasterDocument(int count)
    {
        using (var stream = new MemoryStream())
        {
            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                for (int i = 1; i <= count; ++i)
                {
                    document.Add(new Paragraph(string.Format(
    @"Real name: real-name-{0:D4}
    User name: user-name-{0:D4}
    Password: password-{0:D4}
    Email address: email-{0:D4}@invalid.com",
                     i)));
                    if (i < count) document.NewPage();
                }
            }
            return stream.ToArray();
        }
    }
