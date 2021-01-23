    public class CARDS
    {
        public CARDS(int id, int atk, ClassType ctype, string name)
        {
            this.CARD_ID = id;
            this.C_TYPE = Enum.GetName(ctype.GetType(), ctype); //Use Enum.GetName to get string
            this.ATK = atk;
            this.NAME_EN = name;
        }
        public CARDS()
        {
            this.CARD_ID = -1;
        }
        public int CARD_ID { get; set; }
        public string C_TYPE { get; set; } //change type to string
        public int ATK { get; set; }
        public string NAME_EN { get; set; }
        public enum ClassType
        {
            Warrior,
            Mage,
            Archer,
            Thief,
            Bishop,
            Monk,
            Guardian,
            Destroyer,
            Chaser,
            Hermit,
            Alchemy
        }
    }
