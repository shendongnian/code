    Document doc = new Document();
    
    // Create a list based on one of the Microsoft Word list templates.
    Aspose.Words.Lists.List list = doc.Lists.Add(ListTemplate.NumberDefault);
    
    // Completely customize one list level.
    ListLevel level1 = list.ListLevels[0];
    level1.NumberStyle = NumberStyle.Arabic;
    level1.NumberFormat = "\u0000";
    
    ListLevel level2 = list.ListLevels[1];
    level2.NumberStyle = NumberStyle.Arabic;
    level2.NumberFormat = "\u0000.\u0001";    
    
    DocumentBuilder builder = new DocumentBuilder(doc);
    
    builder.ListFormat.List = list;
    builder.Writeln("Text1_Level1");
    builder.Writeln("Text2_Level1");
    
    builder.ListFormat.ListIndent();
    builder.Writeln("Text1_Level2");
    builder.Writeln("Text2_Level2");
    
    builder.ListFormat.ListOutdent();
    builder.Writeln("Text3_Level1");
    
    builder.ListFormat.RemoveNumbers();
    
    builder.Document.Save("Lists.CreateCustomList.docx");
    
