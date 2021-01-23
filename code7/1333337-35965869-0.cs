    public class TitleClass
    {
      public string Title1 {get;set;}
      public string Title2 {get;set;}
    }
    public void BindListToRepeater()
    {
    List<TitleClass> titleList = new[]{ new TitleClass{ Title1 = "title1", Title2="title2" }};
            rptNames.DataSource = titleList;
            rptNames.DataBind();
    }
