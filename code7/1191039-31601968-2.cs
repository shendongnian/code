    [Serializable]
    public class MapperInfo
    {
        public string Number { get; set; }
        public string Prop1{ get; set; }
        public string Prop2 { get; set; }
        public override string ToString()
        {
            return this.Number + ", " + this.Prop1 + ", " + this.Prop2;
        }
    }
