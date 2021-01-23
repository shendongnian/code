    public interface IResult { }
    public class ResultA : IResult { }
    public class ResultB : IResult { }
    public interface IRequestProcessor //no longer needs generic
    {
        IResult Process();
    }
    IResult result = processor.Process();
