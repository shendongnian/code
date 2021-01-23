    using (SpreadsheetDocument document = SpreadsheetDocument.Open(outputFile, true))
            {
                var chartSheet = document.WorkbookPart.Workbook.Descendants<Sheet>().SingleOrDefault(s => s.Name == "Geo Type Chart");
                if (chartSheet == null)
                {
                    return;
                }
                WorksheetPart wsPart = (WorksheetPart)document.WorkbookPart.GetPartById(chartSheet.Id);
                DrawingsPart dp = wsPart.DrawingsPart;
                ChartPart cp = dp.ChartParts.FirstOrDefault();
                if (cp == null)
                {
                    return;
                }
                C.ChartSpace chartSpace1 = cp.ChartSpace;
                C.Chart chart1=chartSpace1.GetFirstChild<C.Chart>();
                C.PlotArea plotArea1=chart1.GetFirstChild<C.PlotArea>();
                C.CategoryAxis categoryAxis1=plotArea1.GetFirstChild<C.CategoryAxis>();
                C.CrossingAxis crossingAxis1=categoryAxis1.GetFirstChild<C.CrossingAxis>();
                C.TextProperties textProperties1 = new C.TextProperties();
                A.BodyProperties bodyProperties1 = new A.BodyProperties(){ Rotation = 5400000 };
                A.ListStyle listStyle1 = new A.ListStyle();
                A.Paragraph paragraph1 = new A.Paragraph();
                A.ParagraphProperties paragraphProperties1 = new A.ParagraphProperties();
                A.DefaultRunProperties defaultRunProperties1 = new A.DefaultRunProperties();
                paragraphProperties1.Append(defaultRunProperties1);
                A.EndParagraphRunProperties endParagraphRunProperties1 = new A.EndParagraphRunProperties(){ Language = "en-US" };
                paragraph1.Append(paragraphProperties1);
                paragraph1.Append(endParagraphRunProperties1);
                textProperties1.Append(bodyProperties1);
                textProperties1.Append(listStyle1);
                textProperties1.Append(paragraph1);
                categoryAxis1.InsertBefore(textProperties1,crossingAxis1);
            }
