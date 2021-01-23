    public class Movie {
       //Annootations not included
       public int ID {get;set;}
       public string Title {get;set;}
       public string Description {get;set;}
       public string Genre {get;set;}
       public List<int> CommentIds {get;set;}
    }
    public class Comment {
       public int ID {get;set;}
       public int MovieID {get;set;}
       public string Comment {get;set;}
    }
