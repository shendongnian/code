    // Create tag builder
    var builder = new TagBuilder("img");
    //...
    // Render tag approach also changed in .NetCore
    builder.TagRenderMode = TagRenderMode.SelfClosing;
    //Create the StringWriter and make TagBuilder "WriteTo" it
    var stringWriter = new System.IO.StringWriter();
    builder.WriteTo(stringWriter, HtmlEncoder.Default);
    var tagBuilderIsFinallyAStringNow = stringWriter.ToString();
