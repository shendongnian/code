    public class Person
    {
        public int Strength { get; private set; }
        public int Speed { get; private set; }
        public int Intel { get; private set; }
        public int Personality { get; private set; }
        public int Ingenuity { get; private set; }
        public Person (int strength, int speed, int intel, int personality, int ingenuity)
        {
            this.Strength = strength;
            this.Speed = speed;
            this.Intel = intel;
            this.Personality = personality;
            this.Ingenuity = ingenuity;
        }
    }
