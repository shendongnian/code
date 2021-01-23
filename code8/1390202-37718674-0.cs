    using Syncfusion.DocIO.DLS;
    namespace DocIO_Clone
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (WordDocument document = new WordDocument(@"InputWordFile.docx"))
            {
                int sectionCount = document.Sections.Count;
                for (int i = 0; i < sectionCount; i++)
                {
                    IWSection section = document.Sections[i];
                    int entityCount = section.Body.ChildEntities.Count;
                    for (int j = 0; j < entityCount; j++)
                    {
                        IEntity entity = section.Body.ChildEntities[j];
                        switch(entity.EntityType)
                        { 
                            case EntityType.Paragraph:
                                IWParagraph paragraph = entity.Clone() as IWParagraph;
                                document.LastSection.Body.ChildEntities.Add(paragraph);
                                break;
                            case EntityType.Table:
                                IWTable table = entity.Clone() as IWTable;
                                document.LastSection.Body.ChildEntities.Add(table);
                                break;
                        }
                    }
                }
                document.Save("ResultDocument.docx");
            }
        }
    }
    }
