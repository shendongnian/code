    public interface ISomethingThatTheOtherClassNeeds<T>
    {
        public int MySomething {get;set;}
    }
    public class SomethingThatTheOtherClassNeeds : ISomethingThatTheOtherClassNeeds<string>
    {
        public int MySomething {get;set;}
    }
