        public void ExportToPdfTableFULL(DataTable dt, string path)
        {
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            
            if (path.Equals(null) | path.Equals("")) { path = defaultFilename; }
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "_FULL.pdf", FileMode.Create));
            }
            catch (System.NotSupportedException)
            {
                MessageBox.Show("Invalid File Path. The PDF was saved at " + defaultFilename);
                path = defaultFilename;
                
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + "_FULL.pdf", FileMode.Create));
            }
            catch (Exception)
            {
                MessageBox.Show("Please Close Your PDF Viewer to Allow the " + "\nProgram to Overwrite or change the Filename");
            }
            
            document.Open();
            try
            {
                iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("EisenmannLogo.png");
                document.Add(PNG);
            }
            catch (Exception) { }
            Paragraph companyInfo = new Paragraph("\n" + companyName.Text + "-" + textBox4.Text + "\n" + phoneNumber.Text + " | " + textBox3.Text + "\n" + address.Text + "\n" + state.Text + ",  " + zipCode.Text + " " + textBox2.Text + "\n");
            document.Add(companyInfo);
            Paragraph TagName = new Paragraph("\n" +  description.Text + "\n" + "\n");
            document.Add(TagName);
            try
            {
                iTextSharp.text.Image Chart_Image = iTextSharp.text.Image.GetInstance(graphedTags[0] + "_chart.png");
                Chart_Image.ScalePercent(62f);
                document.Add(Chart_Image);
            }
            catch(Exception) { }
            Paragraph Disclaimer = new Paragraph("\n" + "*The data has been printed out at " + printOutInterval + " minute intervals to reduce PDF size.*" + "\n" + "\n");
            Disclaimer.Alignment = Element.ALIGN_CENTER;
            int counterToShorten = 0;
            for (int namesGraphed = 0; namesGraphed < graphedTags.Count; namesGraphed++)
            {
                Paragraph spacing = new Paragraph("\n" + "\n");
                document.Add(spacing);
                PdfPTable table = new PdfPTable(dt.Columns.Count-1);
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                iTextSharp.text.Font fontSize = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font fontSize1 = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font fontSize2 = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);
                PdfPCell cell = new PdfPCell(new Phrase(graphedTags[namesGraphed], fontSize2));
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(0, 0, 0);
                table.AddCell(cell);
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    PdfPCell cell2 = new PdfPCell(new Phrase(dt.Columns[j].ToString(), fontSize1));
                    cell2.HorizontalAlignment = 1;
                    cell2.BackgroundColor = new iTextSharp.text.BaseColor(185, 185, 185);
                    table.AddCell(cell2);
                }
                table.HeaderRows = 1;
                for (int p = 0; p < columnHeaders.Count; p++) { Console.WriteLine(columnHeaders[p]); }
                    document.Add(Disclaimer);
                    for (int i = 0; i < (dt.Rows.Count); i++)
                    {
                        if (columnHeaders.Contains("Tagname"))
                        {
                            if (graphedTags[namesGraphed].Equals(dt.Rows[i]["Tagname"].ToString()))
                            {
                                counterToShorten++;
                                if (counterToShorten >=  printOutInterval)
                                {
                                    for (int k = 1; k < (dt.Columns.Count); k++)
                                    {
                                        if (!dt.Rows[i][k].Equals(null))
                                        {
                                            PdfPCell cell3 = new PdfPCell(new Phrase(dt.Rows[i][k].ToString(), fontSize));
                                            cell3.HorizontalAlignment = 1;
                                            table.AddCell(cell3);
                                            counterToShorten = 0;
                                        }
                                    }
                                }
                            }
                        }
                        if (columnHeaders.Contains("TagIndex"))
                        {
                            if (graphedTags[namesGraphed].Equals(dt.Rows[i]["TagIndex"].ToString()))
                            {
                                counterToShorten++;
                                if (counterToShorten >=printOutInterval)
                                {
                                    for (int k = 1; k < (dt.Columns.Count); k++)
                                    {
                                        int mulitplier = 10 * i;
                                        if (!dt.Rows[i][k].Equals(null))
                                        {
                                            PdfPCell cell3 = new PdfPCell(new Phrase(dt.Rows[i][k].ToString(), fontSize));
                                            cell3.HorizontalAlignment = 1;
                                            table.AddCell(cell3);
                                            counterToShorten = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
               
                document.Add(table);
            }
            document.Close();
