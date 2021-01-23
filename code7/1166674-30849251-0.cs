    // using DocumentFormat.OpenXml.Packaging;
    // using System.Diagnostics;
    // using System.Linq;
    SdtContentCheckBox TryGetCheckBoxByTag(WordprocessingDocument doc, string tag)
    {
        foreach (var checkBox in doc.MainDocumentPart.Document.Descendants<SdtContentCheckBox>())
        {
            var tagProperty = doc.Parent.Descendants<Tag>().FirstOrDefault();
            if (tagProperty != null)
            {
                Debug.Assert(tagProperty.Val != null);
                if (tagProperty.Val.Value == tag)
                {
                    // a checkbox with the given tag property was found
                    return checkBox;
                }
            }
        }
        // no checkbox with the given tag property was found
        return null;
    }
