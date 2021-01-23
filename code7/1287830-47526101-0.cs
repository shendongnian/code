            //Declare a itextSharp document 
            Document document = new Document(PageSize.A4);
            Random ran = new Random();
            string PDFFileName = string.Format(@"C:\Test{0}.Pdf", ran);
            //Create our file stream and bind the writer to the document and the stream 
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(PDFFileName, FileMode.Create));
            //Open the document for writing 
            document.Open();
            //Add a new page 
            document.NewPage();
            var ArialFontFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.ttf");
            //Reference a Unicode font to be sure that the symbols are present. 
            BaseFont bfArialUniCode = BaseFont.CreateFont(ArialFontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a font from the base font 
            Font font = new Font(bfArialUniCode, 12);
            //Use a table so that we can set the text direction 
            var table = new PdfPTable(1)
            {
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
            };
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            table.DefaultCell.NoWrap = false;
            ContentObject CO = new ContentObject();
            CO.Name = "Ahmed Gomaa";
            CO.StartDate = DateTime.Now.AddMonths(-5);
            CO.EndDate = DateTime.Now.AddMonths(43);
            string content = string.Format(" تم إبرام هذا العقد في هذا اليوم من قبل {0} في تاريخ بين {1} و {2}", CO.Name, CO.StartDate, CO.EndDate);
            var phrase = new Phrase(content, font);
            //var phrase = new Phrase("الحمد لله رب العالمين", font);
            //Create a cell and add text to it 
            PdfPCell text = new PdfPCell(phrase)
            {
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                Border = 0
            };
            //Ensure that wrapping is on, otherwise Right to Left text will not display 
            text.NoWrap = false;
            //Add the cell to the table 
            table.AddCell(text);
            //Add the table to the document 
            document.Add(table);
            //Close the document 
            document.Close();
            //Launch the document if you have a file association set for PDF's 
            Process AcrobatReader = new Process();
            AcrobatReader.StartInfo.FileName = PDFFileName;
            AcrobatReader.Start();
        }
    }
    public class ContentObject
    {
        public string Name { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
    }
`
