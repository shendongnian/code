    public class AnimalStock // or AnimalPrice or whatever
    {
        public AnimalStock(Animal animal)
        {
            this.Animal = animal;
        }
        public AnimalStock(Animal animal, decimal worstPrice, decimal bestPrice, int bestStock, int worstStock)
        {
            this.Animal = animal;
            this.Worstprice = worstPrice;
            this.BestPrice = bestPrice;
            this.BestStock = bestStock;
            this.WorstStock = worstStock;
        }
        public Animal Animal { get; set; }
        public decimal Worstprice { get; set; }
        public decimal BestPrice { get; set; }
        public int BestStock { get; set; }
        public int WorstStock { get; set; }
        // ...
    }
