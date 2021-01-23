    public class Entity
    {
        public byte Prop1 { get; set; }
        public byte Prop2 { get; set; }
        public byte Prop3 { get; set; }
        public byte Prop4 { get; set; }
        public Entity()
        {
            Random random = new Random( Guid.NewGuid().GetHashCode() );
            byte[] bytes = new byte[ 4 ];
            random.NextBytes( bytes );
            this.Prop1 = bytes[0];
            this.Prop2 = bytes[1];
            this.Prop3 = bytes[2];
            this.Prop4 = bytes[3];
        }
    }
