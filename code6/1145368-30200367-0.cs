    using System.Xml.Serialization;
    using System.Collections.Generic;
    [XmlRoot("dices")]
    public class DicesElement
    {
        [XmlArray("dice")]
        [XmlArrayItem("dice", Type = typeof(DiceElement))]
        public List<DiceElement> Dice { get; set;}
    }
...
    using System.Xml.Serialization;
    public class DiceElement
    {
        [XmlElement("Sequence")]
        public string Sequence { get; set; }
        [XmlElement("Dice1")]
        public string Dice1{ get; set; }
        [XmlElement("Dice2")]
        public string Dice2{ get; set; }
    }
