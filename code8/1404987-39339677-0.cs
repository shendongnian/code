    class Program
    {
        static void Main(string[] args)
        {
            PdfCommon.Initialize();
            InsertImage();
        }
        static private void InsertImage()
        {
            //Load bitmap from file and insert it into page
            using (var bmp = Bitmap.FromFile(@"d:\0\img1.png") as Bitmap)
            {
                using (var doc = PdfDocument.Load(@"d:\0\test_big.pdf"))
                {
                    foreach (var page in doc.Pages)
                    {
                        var image = InsertImageToPage(doc, page, bmp, new PointF(0, 0));
                        //Insert image into page dictionary
                        InsertIntoDictionary(doc, page, image);
                    }
                    //Save document
                    doc.Save(@"d:\0\6\modified_facture.pdf", SaveFlags.NoIncremental);
                }
            }
        }
        static public PdfImageObject InsertImageToPage(PdfDocument doc, PdfPage page, System.Drawing.Bitmap bmp, PointF atPoint)
        {
            var bi = bmp.LockBits(
                new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Create PdfBitmap object from .Net bitmap
            var bitmap = new PdfBitmap(
                bmp.Width,
                bmp.Height,
                BitmapFormats.FXDIB_Argb,
                bi.Scan0,
                bi.Stride);
            //Create pdf image object and then set PdfBitmap object into it.
            var image = PdfImageObject.Create(doc);
            image.SetBitmap(bitmap);
            //Scale image object to it's actual width and heihgt
            image.SetMatrix(bmp.Width, 0, 0, bmp.Height, (float)atPoint.X, (float)atPoint.Y);
            page.PageObjects.InsertObject(image);
            bmp.UnlockBits(bi);
            return image;
        }
        static private void InsertIntoDictionary(PdfDocument doc, PdfPage page, PdfImageObject image)
        {
            //Get page dictionary, list of indirect objects and original page content
            var pageDict = page.Dictionary;
            var list = PdfIndirectList.FromPdfDocument(doc);
            //Convert contents to array. 
            PdfTypeArray array = ConvertContentsToArray(pageDict["Contents"], list, pageDict);
            //Get stream of image.
            IntPtr streamHandle = Pdfium.FPDFImageObj_GenerateStream(image.Handle, page.Handle);
            var stream = PdfTypeStream.Create(streamHandle);
            //Add image's stream into list of indirect objects and then add it to array.
            int num = list.Add(stream);
            array.AddIndirect(list, num);
        }
        static private PdfTypeArray ConvertContentsToArray(PdfTypeBase contents, PdfIndirectList list, PdfTypeDictionary pageDict)
        {
            //check the original content whether it's an array
            if (contents is PdfTypeArray)
                return contents as PdfTypeArray;  //if contents is a array just return it
            else if (contents is PdfTypeIndirect)
            {
                if ((contents as PdfTypeIndirect).Direct is PdfTypeArray)
                    return (contents as PdfTypeIndirect).Direct as PdfTypeArray; //if contents is a reference to array then return that array
                else if ((contents as PdfTypeIndirect).Direct is PdfTypeStream)
                {
                    //if contents is a reference to a stream then create a new array and insert stream as a first element of array
                    var array = PdfTypeArray.Create();
                    array.AddIndirect(list, (contents as PdfTypeIndirect).Direct);
                    //Add array into list of indirect objects
                    list.Add(array);
                    //And set it as a contents of the page
                    pageDict.SetIndirectAt("Contents", list, array);
                    return array;
                }
                else
                    throw new Exception("Unexcpected content type");
            }
            else
                throw new Exception("Unexcpected content type");
        }
    }
