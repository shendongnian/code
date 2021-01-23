    public class SearchedTerms
    {
        public string FirstName {get;set;}
        ...
        public int Age {get;set;}
    }
    
    public Expression<Func<Student,bool>> GetPredicateExpression(SearchedTerms terms)
    {
        // ...
    }
