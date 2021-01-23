    public class SpeedBoat<T> : Boat where T: IXmlSerializable
    {
        public int MaxSpeed { get; set; }
        public Engine<T> Engine { get; set; }
    }
