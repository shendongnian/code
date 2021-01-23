            public string GenerateStyleSheet()
        {
            if (this.StylesheetFormat == null)
            {
                using (var styleXmlReader = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\bin\Resources\ExcelStyleSheet.xml"))
                {
                    this.StylesheetFormat = styleXmlReader.ReadToEnd();
                }
            }
            
            return this.StylesheetFormat;
        }
