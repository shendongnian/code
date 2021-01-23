       Document document = new Document();
                document.LoadFromFile(@"d:\a.docx");
    
                //Initialzie StringBuilder Instance
                StringBuilder sb = new StringBuilder();
    
                //Extract Text from Word and Save to StringBuilder Instance
                foreach (Section section in document.Sections)
                {
                    foreach (Paragraph paragraph in section.Paragraphs)
                    {
                        sb.AppendLine(paragraph.Text);
                    }
                }
    
                //Create a New TXT File to Save Extracted Text
                Console.WriteLine(sb.ToString());
                Console.ReadLine();
