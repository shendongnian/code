    public class Things: ObservableCollection<Thing>
    {
        public Things()
        {
            this.Add(new Thing() { Id = 1, Name = "Maxime" });
            this.Add(new Thing() { Id = 2, Name = "Konrad" });
        }
    }
