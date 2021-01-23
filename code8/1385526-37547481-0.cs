    var document = new Document();
    document
        .AddField(new TextField("CS Counter Basic Name", "Case Study"))
        .AddField(new TextField("CS Counter Number", _numberInParentDocument.ToString()))
        .AddField(new TextField("Page Title", caseStudyPage.Page_Title))
        .AddField(new TextField("Common Footer Text 1", commonFooterText1))
        .AddField(new TextField("Page Title Content", caseStudyPage.Page_Title));
    
    var table = document.AddTable(new Table("Images"));
    foreach (var imageId in imageIds)
    {
        byte[] csImage = GetImage(imageId);
        table.AddRow(new TableRow().AddField(new ImageField("Image", csImage, ImageType.Jpeg))
                .AddField(new TextField("Overview", caseStudyPage.Overview))
                .AddField(new TextField("Engagement", caseStudyPage.Engagement))
                .AddField(new TextField("Publish Date", caseStudyPage.Publish_Date.ToString("MMM. dd, yyyy")));
    }
    
    document.AddField(new TextField("Common Footer Text 2", commonFooterText2))));
