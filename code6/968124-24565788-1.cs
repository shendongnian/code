    using (WordprocessingDocument document = WordprocessingDocument.Create("TableDoesNotBreakAcrossPage.docx", WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = document.AddMainDocumentPart();
                #region Styles
                Styles styles = new Styles();
                Style style = new Style() { Type = StyleValues.Table, StyleId = "TableGrid" };
                StyleName styleName10 = new StyleName() { Val = "Table Grid" };
                BasedOn basedOn2 = new BasedOn() { Val = "TableNormal" };
                UIPriority uIPriority8 = new UIPriority() { Val = 59 };
                Rsid rsid7 = new Rsid() { Val = "003B7411" };
                StyleParagraphProperties styleParagraphProperties2 = new StyleParagraphProperties();
                SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
                styleParagraphProperties2.Append(spacingBetweenLines4);
                StyleTableProperties styleTableProperties4 = new StyleTableProperties();
                TableIndentation tableIndentation4 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };
                TableBorders tableBorders2 = new TableBorders();
                TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                InsideHorizontalBorder insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                InsideVerticalBorder insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
                tableBorders2.Append(topBorder2);
                tableBorders2.Append(leftBorder2);
                tableBorders2.Append(bottomBorder2);
                tableBorders2.Append(rightBorder2);
                tableBorders2.Append(insideHorizontalBorder2);
                tableBorders2.Append(insideVerticalBorder2);
                TableCellMarginDefault tableCellMarginDefault4 = new TableCellMarginDefault();
                TopMargin topMargin4 = new TopMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };
                TableCellLeftMargin tableCellLeftMargin4 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
                BottomMargin bottomMargin4 = new BottomMargin() { Width = "200", Type = TableWidthUnitValues.Dxa };
                TableCellRightMargin tableCellRightMargin4 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };
                tableCellMarginDefault4.Append(topMargin4);
                tableCellMarginDefault4.Append(tableCellLeftMargin4);
                tableCellMarginDefault4.Append(bottomMargin4);
                tableCellMarginDefault4.Append(tableCellRightMargin4);
                styleTableProperties4.Append(tableIndentation4);
                styleTableProperties4.Append(tableBorders2);
                styleTableProperties4.Append(tableCellMarginDefault4);
                style.Append(styleName10);
                style.Append(basedOn2);
                style.Append(uIPriority8);
                style.Append(rsid7);
                style.Append(styleParagraphProperties2);
                style.Append(styleTableProperties4);
                styles.Append(style);
                StyleDefinitionsPart styleDefinitionsPart = mainDocumentPart.AddNewPart<StyleDefinitionsPart>("Styles");
                styleDefinitionsPart.Styles = styles;
                #endregion
                mainDocumentPart.Document =
                new Document(
                    new Body(
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Paragraph(
                            new Run(
                                new Text("Test"))),
                        new Table(
                            new TableProperties(
                                new TableStyle() { Val = "TableGrid" },
                                new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto }),
                            new TableGrid(
                                new GridColumn() { Width = "2000" },
                                new GridColumn() { Width = "2000" },
                                new GridColumn() { Width = "2000" },
                                new GridColumn() { Width = "2000" }),
                            new TableRow(
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 1")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 1")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 1")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 1"))))),
                           new TableRow(
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 2")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 2")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 2")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 2"))))),
                          new TableRow(
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 3")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 3")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 3")))),
                                new TableCell(
                                    new Paragraph(
                                        new ParagraphProperties(
                                            new KeepNext(),
                                            new KeepLines()),
                                        new Run(
                                        new Text("Table Row 3"))))),
                         new TableRow(
                                new TableCell(
                                    new Paragraph(
                                        new Run(
                                        new Text("Table Row 4")))),
                                new TableCell(
                                    new Paragraph(
                                        new Run(
                                        new Text("Table Row 4")))),
                                new TableCell(
                                    new Paragraph(
                                        new Run(
                                        new Text("Table Row 4")))),
                                new TableCell(
                                    new Paragraph(
                                        new Run(
                                        new Text("Table Row 4"))))))));
            }
