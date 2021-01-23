    public partial class schakeling : IPKProvider
    {
        public bool PKHasNoValue() {
            return this.id == 0;
        }
    }
