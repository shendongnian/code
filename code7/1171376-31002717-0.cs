    HtmlGenericControl li = new HtmlGenericControl("li");
    li.ID = "liQuestions" + recordcount.ToString();
    li.Attributes.Add("role", "Presentation");
    ULRouting.Controls.Add(li);
    
    HtmlGenericControl anchor = new HtmlGenericControl("a");
    li.Attributes.Add("myCustomIDAtribute", recordcount.ToString());
    anchor.InnerHtml = "Test <br/> 12345";
    li.Controls.Add(anchor);
