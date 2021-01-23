    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    public static class ContentControlExtensions
    {
    
        public static IEnumerable<ContentControl> ContentControls(this OpenXmlPart part)
        {
            var results = new List<ContentControl>();
    
            IEnumerable<OpenXmlElement> parents = part.RootElement
                .Descendants()
                 .Where(e => e is SdtProperties)
                 .Select(p => p.Parent);
    
            foreach(var parent in parents)
            {
                ParseContentControl(results, parent);
    
            }
    
            return results;
        }
    
        private static void ParseContentControl(List<ContentControl> results, OpenXmlElement parent)
        {
            var sdtAlias = parent.ChildElements.Where(p => p is SdtProperties).FirstOrDefault()
                    .ChildElements.Where(c => c is SdtAlias).FirstOrDefault();
    
            if (sdtAlias != null)
            {
                string value = string.Empty;
                var name = ((SdtAlias)sdtAlias).Val;
    
                var sdtContentCell = parent.ChildElements.Where(p => p is SdtContentCell).FirstOrDefault();
    
                if (sdtContentCell != null)
                {
                    value = sdtContentCell.InnerText;
                    if (value == "Click or tap here to enter text.")
                    {
                        value = null;
                    }
                }
    
                var sdtid = parent.ChildElements.Where(p => p is SdtProperties).FirstOrDefault()
                    .ChildElements.Where(c => c is SdtId).FirstOrDefault();
                var id = ((SdtId)sdtid).Val;
    
    
                var sdtTag = parent.ChildElements.Where(p => p is SdtProperties).FirstOrDefault()
                        .ChildElements.Where(c => c is Tag).FirstOrDefault();
                var tag = ((Tag)sdtTag).Val;
    
                results.Add(new ContentControl() { Title = name, Value = value, id = id, Tag = tag });
            }
        }
    
        public static IEnumerable<ContentControl> ContentControls(
        this WordprocessingDocument doc)
        {
            foreach (var cc in doc.MainDocumentPart.ContentControls())
                yield return cc;
            foreach (var header in doc.MainDocumentPart.HeaderParts)
                foreach (var cc in header.ContentControls())
                    yield return cc;
            foreach (var footer in doc.MainDocumentPart.FooterParts)
                foreach (var cc in footer.ContentControls())
                    yield return cc;
            if (doc.MainDocumentPart.FootnotesPart != null)
                foreach (var cc in doc.MainDocumentPart.FootnotesPart.ContentControls())
                    yield return cc;
            if (doc.MainDocumentPart.EndnotesPart != null)
                foreach (var cc in doc.MainDocumentPart.EndnotesPart.ContentControls())
                    yield return cc;
        }
    
        public class ContentControl
        {
            public string Title {get; set; }
            public string Value { get; set; }
            public string Tag { get; set; }
            public string id { get; set; }
    
        }
    }
