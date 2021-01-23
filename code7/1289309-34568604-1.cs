    public class Promotion : Product, IPromotion
    {
        public Promotion(int id, string name, decimal price, DateTime? date) : base (id, name, price)
        {
            Date = date;
        }
       
        public DateTime? Date { get; }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Promotion:");
            builder.AppendLine($"Id: {Id}");
            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Price: {Price}");
            builder.AppendLine(string.Format("Date: {0}", Date != null ? Date.Value.ToString("yyyy-MM-dd") : string.Empty));
            return builder.ToString();
        }
    }
