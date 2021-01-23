    private static readonly CompiledExpression<Customer, string> fullNameExpression
       = DefaultTranslationOf<User>.Property(e => e.FullName)
                    .Is(e => e.FirstName + " " + e.LastName);
    
    [NotMapped]
    public string FullName
    {
         get { return fullNameExpression.Evaluate(this); }
    }
    var q = dbContext.Users.Select(u => new
         {
             FullName = u.FullName
         }).WithTranslations(); 
