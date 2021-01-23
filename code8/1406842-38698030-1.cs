                if (bookmark != null)
            {
                var parent = bookmark.Parent;   // bookmark's parent element
                var childEllement = parent.Elements<Run>().Last();
                var lastChild = childEllement.LastChild;
                childEllement.RemoveChild(lastChild);
                foreach (var itemChild in groupList)
                {
                    Paragraph paragraph1 = new Paragraph();
                    ParagraphProperties paragraphProperties = new ParagraphProperties();
                    ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "ListParagraph" };
                    Tabs tabs = new Tabs();
                    TabStop tabStop1 = new TabStop() { Val = TabStopValues.Left, Position = 284 };
                    tabs.Append(tabStop1);
                    SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "120", Line = "360", LineRule = LineSpacingRuleValues.Auto };
                    Indentation indentation1 = new Indentation() { Left = "0", FirstLine = "0" };
                    Justification justification = new Justification() { Val = JustificationValues.Both };
                    ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
                    paragraphProperties.Append(paragraphStyleId1);
                    paragraphProperties.Append(tabs);
                    paragraphProperties.Append(spacingBetweenLines1);
                    paragraphProperties.Append(indentation1);
                    paragraphProperties.Append(justification);
                    paragraphProperties.Append(paragraphMarkRunProperties1);
                    Run run1 = new Run();
                    RunProperties runProperties1 = new RunProperties();
                    Bold bold2 = new Bold();
                    FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "24" };
                    runProperties1.Append(bold2);
                    runProperties1.Append(fontSizeComplexScript2);
                    Text text1 = new Text();
                    text1.Text = "- " + itemChild + ";";
                    run1.Append(runProperties1);
                    run1.Append(text1);
                    paragraph1.Append(paragraphProperties);
                    paragraph1.Append(run1);
                    parent.InsertAfterSelf(paragraph1);
                }
            }
