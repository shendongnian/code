    interface INews
    {
        DateTime PublishDate { get; }
    }
    class NewsRU : INews
    {
         public string Text {get; set; }
         public DateTime PublishDate {get; set;}
    }
    
    ...
    
    public static void IQueryable<T> GetTodaysNews<T>(this IQueryable<T> source) where T:INews
    {
        return from n in source
               where n.PublishDate > DateTime.Now.Date
               select n;
    }
    ...
    result.GetTodaysNews(); //whatever result is it will work
