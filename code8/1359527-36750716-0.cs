    public class ModelData
    {
        public string name;
        public DateTime DT;
        public int real;
        public int trade;
        public int position;
        public int dayPnl;
        public double ATR;
        public double C2C;
        public double C;
    }
    private class ModelDataNameComparator : IEqualityComparer<ModelData>
    {
        public bool Equals(ModelData x, ModelData y)
        {
            return x.name.Equals(x.name.ID);
        }
        public int GetHashCode(ModelData obj)
        {
            return obj.name.GetHashCode();
        }
    }
    public class Program
    {
        static void Main()
        {        
            List<ModelData> modelData = ModelRepository.GetAllModelDataFromMagicPlace();
            var priorDateRealTrades = modelData.OrderByDescending(d => d.DT)
                                               .Distinct(new ModelDataNameComparator())
                                               .ToList();
            foreach(ModelData md in priorDateREalTrades)
            {
                Console.WriteLine("name: {0}, Date: {1}", md.name, md.DT);
            }
        }
    }
