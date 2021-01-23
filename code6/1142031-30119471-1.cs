    public void showSignatureValues(PdfReader reader)
    {
        AcroFields fields = reader.AcroFields;
        foreach (String name in fields.GetSignatureNames())
        {
            Console.Write(" Signature {0}\n", name);
            PdfDictionary sigDict = fields.GetSignatureDictionary(name);
            PdfName subFilter = sigDict.GetAsName(PdfName.SUBFILTER);
            Console.Write("  SubFilter {0}\n", subFilter);
            PdfString contents = sigDict.GetAsString(PdfName.CONTENTS);
            if (contents != null)
            {
                byte[] contentBytes = contents.GetOriginalBytes();
                string contentBas64 = Convert.ToBase64String(contentBytes);
                // contentBytes contains the actual signature container as is,
                // contentBas64 contains it encoded using Base64 for better printability
                Console.Write("  Content {0}\n", contentBas64);
            }
        }
    }
