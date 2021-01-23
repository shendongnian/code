    public class Program
    {
        public static void Main(string[] args)
        {
            string xml = @"<Dices>
      <Dice>
        <Sequence>1</Sequence>
        <Dice1>2</Dice1>
        <Dice2>2</Dice2>
      </Dice>
      <Dice>
        <Sequence>2</Sequence>
        <Dice1>3</Dice1>
        <Dice2>4</Dice2>
      </Dice></Dices>";
            XDocument xd = XDocument.Parse(xml);
            Dice[] load_dices = (from dice in xd.Root.Elements("Dice")
                                 select new Dice
                                 {
                                     Sequence = (int)dice.Element("Sequence"),
                                     Dice1 = (int)dice.Element("Dice1"),
                                     Dice2 = (int)dice.Element("Dice2")
                                 }).ToArray();
            foreach (var x in load_dices)
                Console.WriteLine(x);
        }
    }
    public class Dice
    {
        public int Sequence { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
    
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", Sequence, Dice1, Dice2);
        }
    }
