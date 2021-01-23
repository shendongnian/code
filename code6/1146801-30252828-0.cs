    static void Main(string[] args)
    {
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        // 'INPUT' => **YOUR** already rendered pdf in iText
        PdfReader reader = new PdfReader(INPUT);
        string outputFile = Path.Combine(currentDir, OUTPUT);
        using (var stream = new FileStream(outputFile, FileMode.Create)) 
        {
            using (PdfStamper stamper = new PdfStamper(reader, stream))
            {
                AcroFields form = stamper.AcroFields;
                var fldPosition = form.GetFieldPositions("lname")[0];
                Rectangle rectangle = fldPosition.position;
                string base64Image = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";
                Regex regex = new Regex(@"^data:image/(?<mediaType>[^;]+);base64,(?<data>.*)");
                Match match = regex.Match(base64Image);
                Image image = Image.GetInstance(
                    Convert.FromBase64String(match.Groups["data"].Value)
                );
                // best fit if image bigger than form field
                if (image.Height > rectangle.Height || image.Width > rectangle.Width)
                {
                    image.ScaleAbsolute(rectangle.Width, rectangle.Height);
                }
                image.SetAbsolutePosition(rectangle.Left, rectangle.Bottom);
                stamper.GetOverContent(fldPosition.page).AddImage(image);
            }
        }
    }
