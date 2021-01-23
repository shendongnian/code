    public static void dotx2docx(string sourceFile, string targetFile)
        {
            MemoryStream documentStream;
            using (Stream tplStream = File.OpenRead(sourceFile))
            {
                documentStream = new MemoryStream((int)tplStream.Length);
                CopyStream(tplStream, documentStream);
                documentStream.Position = 0L;
            }
            using (WordprocessingDocument template = WordprocessingDocument.Open(documentStream, true))
            {
                template.ChangeDocumentType(DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
                MainDocumentPart mainPart = template.MainDocumentPart;
                mainPart.DocumentSettingsPart.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/attachedTemplate",
                   new Uri(targetFile, UriKind.Absolute));
                mainPart.Document.Save();
            }
            File.WriteAllBytes(targetFile, documentStream.ToArray());
        }
        public static void CopyStream(Stream source, Stream target)
        {
            if (source != null)
            {
                MemoryStream mstream = source as MemoryStream;
                if (mstream != null) mstream.WriteTo(target);
                else
                {
                    byte[] buffer = new byte[2048];
                    int length = buffer.Length, size;
                    while ((size = source.Read(buffer, 0, length)) != 0)
                        target.Write(buffer, 0, size);
                }
            }
        }
        public static void Mailmerge(string templatePath, string DestinatePath, DataRow dr, DataColumnCollection columns)
        {
            dotx2docx(templatePath, DestinatePath);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(DestinatePath, true))
            {
                var allParas = doc.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>();
                Text PreItem = null;
                string PreItemConstant = null;
                bool FindSingleAnglebrackets = false;
                bool breakFlag = false;
                List<Text> breakedFiled = new List<Text>();
                foreach (Text item in allParas)
                {
                    foreach (DataColumn cl in columns)
                    {
                        //<Today>
                        if (item.Text.Contains("«" + cl.ColumnName + "»") || item.Text.Contains("<" + cl.ColumnName + ">"))
                        {
                            item.Text = item.Text.Replace("<" + cl.ColumnName + ">", dr[cl.ColumnName].ToString())
                                                 .Replace("«" + cl.ColumnName + "»", dr[cl.ColumnName].ToString());
                            FindSingleAnglebrackets = false;
                            breakFlag = false;
                            breakedFiled.Clear();
                        }
                        else if //<Today
                        (item.Text != null
                            && (
                                    (item.Text.Contains("<") && !item.Text.Contains(">"))
                                    || (item.Text.Contains("«") && !item.Text.Contains("»"))
                                )
                            && (item.Text.Contains(cl.ColumnName))
                        )
                        {
                            FindSingleAnglebrackets = true;
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"\<" + cl.ColumnName + @"(?!\w)", dr[cl.ColumnName].ToString());
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"\«" + cl.ColumnName + @"(?!\w)", dr[cl.ColumnName].ToString());
                        }
                        else if //Today> or Today
                        (
                            PreItemConstant != null
                            && (
                                    (PreItemConstant.Contains("<") && !PreItemConstant.Contains(">"))
                                    || (PreItemConstant.Contains("«") && !PreItemConstant.Contains("»"))
                                )
                            && (item.Text.Contains(cl.ColumnName))
                        )
                        {
                            if (item.Text.Contains(">") || item.Text.Contains("»"))
                            {
                                FindSingleAnglebrackets = false;
                                breakFlag = false;
                                breakedFiled.Clear();
                            }
                            else
                            {
                                FindSingleAnglebrackets = true;
                            }
                            if (PreItemConstant == "<" || PreItemConstant == "«")
                            {
                                PreItem.Text = "";
                            }
                            else
                            {
                                PreItem.Text = global::System.Text.RegularExpressions.Regex.Replace(PreItemConstant, @"\<" + cl.ColumnName + @"(?!\w)", dr[cl.ColumnName].ToString());
                                PreItem.Text = global::System.Text.RegularExpressions.Regex.Replace(PreItemConstant, @"\«" + cl.ColumnName + @"(?!\w)", dr[cl.ColumnName].ToString());
                            }
                            if (PreItemConstant.Contains("<") || PreItemConstant.Contains("«")) // pre item is like '[blank]«'
                            {
                                PreItem.Text = PreItem.Text.Replace("<", "");
                                PreItem.Text = PreItem.Text.Replace("«", "");
                            }
                            if (item.Text.Contains(cl.ColumnName + ">") || item.Text.Contains(cl.ColumnName + "»"))
                            {
                                item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"(?<!\w)" + cl.ColumnName + @"\>", dr[cl.ColumnName].ToString());
                                item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"(?<!\w)" + cl.ColumnName + @"\»", dr[cl.ColumnName].ToString());
                            }
                            else
                            {
                                item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"(?<!\w)" + cl.ColumnName + @"(?!\w)", dr[cl.ColumnName].ToString());
                            }
                        }
                        else if (FindSingleAnglebrackets && (item.Text.Contains("»") || item.Text.Contains(">")))
                        {
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"(?<!\w)" + cl.ColumnName + @"\>", dr[cl.ColumnName].ToString());
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"(?<!\w)" + cl.ColumnName + @"\»", dr[cl.ColumnName].ToString());
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"^\s*\>", "");
                            item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"^\s*\»", "");
                            FindSingleAnglebrackets = false;
                            breakFlag = false;
                            breakedFiled.Clear();
                        }
                        else if (item.Text.Contains("<") || item.Text.Contains("«")) // no ColumnName
                        {
                        }
                    } //end of each columns
                    PreItem = item;
                    PreItemConstant = item.Text;
                    if (breakFlag
                        || (item.Text.Contains("<") && !item.Text.Contains(">"))
                        || (item.Text.Contains("«") && !item.Text.Contains("»"))
                       )
                    {
                        breakFlag = true;
                        breakedFiled.Add(item);
                        string combinedfiled = "";
                        foreach (Text t in breakedFiled)
                        {
                            combinedfiled += t.Text;
                        }
                        foreach (DataColumn cl in columns)
                        {
                            //<Today>
                            if (combinedfiled.Contains("«" + cl.ColumnName + "»") || combinedfiled.Contains("<" + cl.ColumnName + ">"))
                            {
                                //for the first part, remove the last '<' and tailing content
                                breakedFiled[0].Text = global::System.Text.RegularExpressions.Regex.Replace(breakedFiled[0].Text, @"<\w*$", "");
                                breakedFiled[0].Text = global::System.Text.RegularExpressions.Regex.Replace(breakedFiled[0].Text, @"<\w*$", "");
                                //remove middle parts
                                foreach (Text t in breakedFiled)
                                {
                                    if (!t.Text.Contains("<") && !t.Text.Contains("«") && !t.Text.Contains(">") && !t.Text.Contains("»"))
                                    {
                                        t.Text = "";
                                    }
                                }
                                //for the last part(as current item), remove leading content till the first '>' 
                                item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"^\s*\>", dr[cl.ColumnName].ToString());
                                item.Text = global::System.Text.RegularExpressions.Regex.Replace(item.Text, @"^\s*\»", dr[cl.ColumnName].ToString());
                                FindSingleAnglebrackets = false;
                                breakFlag = false;
                                breakedFiled.Clear();
                                break;
                            }
                        }
                    }
                }//end of each item
                #region go through footer
                MainDocumentPart mainPart = doc.MainDocumentPart;
                foreach (FooterPart footerPart in mainPart.FooterParts)
                {
                    Footer footer = footerPart.Footer;
                    var allFooterParas = footer.Descendants<Text>();
                    foreach (Text item in allFooterParas)
                    {
                        foreach (DataColumn cl in columns)
                        {
                            if (item.Text.Contains("«" + cl.ColumnName + "»") || item.Text.Contains("<" + cl.ColumnName + ">"))
                            {
                                item.Text = (string.IsNullOrEmpty(dr[cl.ColumnName].ToString()) ? " " : dr[cl.ColumnName].ToString());
                                FindSingleAnglebrackets = false;
                            }
                            else if (PreItem != null && (PreItem.Text == "<" || PreItem.Text == "«") && (item.Text.Trim() == cl.ColumnName))
                            {
                                FindSingleAnglebrackets = true;
                                PreItem.Text = "";
                                item.Text = (string.IsNullOrEmpty(dr[cl.ColumnName].ToString()) ? " " : dr[cl.ColumnName].ToString());
                            }
                            else if (FindSingleAnglebrackets && (item.Text == "»" || item.Text == ">"))
                            {
                                item.Text = "";
                                FindSingleAnglebrackets = false;
                            }
                        }
                        PreItem = item;
                    }
                }
                #endregion
                #region replace \v to new Break()
                var body = doc.MainDocumentPart.Document.Body;
                
                var paras = body.Elements<Paragraph>();
                foreach (var para in paras)
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            if (text.Text.Contains("MS_Doc_New_Line"))
                            {
                                string[] ss = text.Text.Split(new string[] { "MS_Doc_New_Line" }, StringSplitOptions.None);
                                text.Text = text.Text = "";
                                int n = 0;
                                foreach (string s in ss)
                                {
                                    n++;
                                    run.AppendChild(new Text(s));
                                    if (n != ss.Length)
                                    {
                                        run.AppendChild(new Break());
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                doc.MainDocumentPart.Document.Save();
            }
        }
        public static void MergeDocuments(params string[] filepaths)
        {
            //filepaths = new[] { "D:\\one.docx", "D:\\two.docx", "D:\\three.docx", "D:\\four.docx", "D:\\five.docx" };
            if (filepaths != null && filepaths.Length > 1)
                using (WordprocessingDocument myDoc = WordprocessingDocument.Open(@filepaths[0], true))
                {
                    MainDocumentPart mainPart = myDoc.MainDocumentPart;
                    for (int i = 1; i < filepaths.Length; i++)
                    {
                        string altChunkId = "AltChunkId" + i;
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(
                            AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        using (FileStream fileStream = File.Open(@filepaths[i], FileMode.Open))
                        {
                            chunk.FeedData(fileStream);
                        }
                        DocumentFormat.OpenXml.Wordprocessing.AltChunk altChunk = new DocumentFormat.OpenXml.Wordprocessing.AltChunk();
                        altChunk.Id = altChunkId;
                        //new page, if you like it...
                        mainPart.Document.Body.AppendChild(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
                        //next document
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<Paragraph>().Last());
                    }
                    mainPart.Document.Save();
                    myDoc.Close();
                }
        }
