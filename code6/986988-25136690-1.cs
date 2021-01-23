    string pdfFilePath = @"D:\Raja\Testing\AuthorQuery\xxx.pdf";
    string dPDFFile = @"D:\Raja\Testing\AuthorQuery\YYY.pdf";
    
    PdfReader pdfR = new PdfReader(pdfFilePath);
    Dictionary<object, PdfObject> nDest = new Dictionary<object, PdfObject>();
    
    nDest = pdfR.GetNamedDestination();
    
    List<object> nDesColl = new List<object>();
    
    nDesColl.Clear();
    
    foreach (KeyValuePair<object, PdfObject> sEntry in nDest)
    {
        PdfArray pArr = (PdfArray)sEntry.Value;
        if(pArr.ArrayList.Count== 6)
        {
            if (pArr[1].ToString() == "/FitR")
            {
    nDesColl.Add(sEntry.Key);
            }
        }
    }
    
    if (nDesColl.Count > 0)
    {
        foreach (object keyVal in nDesColl)
        {
            PdfNumber pNo = new PdfNumber(0);
            PdfArray pArr = (PdfArray)nDest[keyVal];
            pArr[1] = PdfName.XYZ;
            pArr[4] = (PdfObject)pNo;
            pArr.ArrayList.RemoveAt(5);
            PdfObject fVal = (PdfObject)pArr;
            nDest[keyVal] = fVal;
        }
    }
    
    using (PdfStamper stamper = new PdfStamper(pdfR, new FileStream(dPDFFile, FileMode.Create)))
    {
    }
