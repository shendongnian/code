    public abstract class Pagination<T>
    {
        public abstract List<T> Items { get; set; }
    }
    public class OrderHeader : Pagination<OrderLine>
    {
        public override List<OrderLine> Items { get; set; }
    }
    public class OrderLine : Pagination<OrderLineDetails>
    {
        public override List<OrderLineDetails> Items { get; set; }
    }
