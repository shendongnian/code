    public class FileRepository
    {
        public FileRepository()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, string.Empty);
            }
        }
        public decimal CurrentTotal()
        {
            var lines = File.ReadLines(FilePath);
            var lastValue = lines.LastOrDefault();
            return decimal.Parse(lastValue ?? "0");
        }
        public void AddMoney(decimal amount)
        {
            var newTotal = CurrentTotal() + amount;
            File.AppendAllLines(FilePath, new[] { newTotal.ToString(CultureInfo.InvariantCulture) });
        }
        protected static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage.txt");
    }
