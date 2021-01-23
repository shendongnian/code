    public interface IPayment
    {
        Result ProcessPayment();
    }
    public class Result
    {
        public Result(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
