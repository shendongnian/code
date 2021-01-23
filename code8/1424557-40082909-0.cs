            Doc.AddHeaders();
            var headerDefault = Doc.Headers.odd;
            var headlineFormat = GetTopHeadlineFormat();
            var logo = System.Drawing.Image.FromFile(AppSettings.MulalleyLogoSmall);
            using (var ms = new MemoryStream())
            {
                logo.Save(ms, logo.RawFormat);
                ms.Seek(0, SeekOrigin.Begin);
                var img = Doc.AddImage(ms);
                var pic1 = img.CreatePicture();
                var p = headerDefault.InsertParagraph();
                p.InsertPicture(pic1);
                p.InsertParagraphBeforeSelf(Doc.InsertParagraph());
            }
