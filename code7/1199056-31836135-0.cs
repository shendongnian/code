    public class t_option
    {
        [XmlAttribute]
        public string optionImage { get; set; } 
        [XmlAttribute]
        public string optionid { get; set; } 
        [XmlAttribute]
        public string RowId { get; set; }
    }
    public class Color
    {
        public Color()
        {
            t_options = new List<t_option>();
        }
          
        [XmlElement("t_options")]
        public List<t_option> t_options {get; set;} 
    }
    public static void Main(string[] args)
    {
        string xml = @"<Color>
      <t_options optionImage='1593-Black.png' optionid='4625050'  RowId='1' />
      <t_options optionImage='1593-Red.png' optionid='4625051'  RowId='2' />
      <t_options optionImage='1593-Blue.png' optionid='4625052'  RowId='3' />
      <t_options optionImage='1593-Green.png' optionid='4625053'  RowId='4' />
    </Color>";
        XmlSerializer xser = new XmlSerializer(typeof(Color));
        using (XmlReader xr = XmlReader.Create(new StringReader(xml)))
        {
            xr.MoveToContent();
            Color c = (Color)xser.Deserialize(xr);
            Console.WriteLine(c.t_options.Count);
        }
        //   Console.WriteLine(l.Count);
        Console.ReadKey();
    }
