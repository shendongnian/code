    namespace Test.Data
    { 
       [Table("Parameter")]
       public partial abstract class Parameter 
       {
            [StringLength(200)]
            protected string title { get; set; }
    
            protected decimal? num { get; set; }
    
            public Int16 sts { get; set; }
    
       }
    }
    namespace Test.Data
    { 
       public partial abstract class Parameter 
       {
            public class PropertyAccessExpressions
    		{
    			public static readonly Expression<Func<Parameter, string>> Title = x => x.title;
    		}
       }
    }
