    public class LanguageMap : BaseEntityMap<Language>
    {
        public LanguageMap(): base()
        {
            this.Table("Language");
            this.Map(x => x.Name);
            this.HasMany(x => x.MyClass)
                    .Access.CamelCaseField(Prefix.Underscore)
                    .Fetch.Select()
                    .LazyLoad()
                    .KeyColumns.Add("\"LanguageId\""); // database property name : LanguageId
        }
    }
    public class MyClassMap : BaseEntityMap<MyClass>
    {
        public MyClassMap(): base()
        {
            this.Table("MyClass");
            this.References(x => x.Language).Column("LanguageId");
        }
    }
