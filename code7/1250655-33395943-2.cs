    public void AssignLanguageListToRepeater()
    {
         List<Language> languages = new List<Language>
         {
             new Language{LangID="1", LangName="English"},
             new Language{LangID="2", LangName="Spanish"}
         };
         Repeater1.DataSource = languages;
         Repeater1.DataBind();
    }
