    public class B : IHasNumber 
    { 
        public B(A data) { this.Data = data; }
        private A Data { get; private set; }
        public int Number { get { Data.Number; } } 
     }
