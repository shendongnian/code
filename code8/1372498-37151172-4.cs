    public class Repeat : Command
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
        public override void Process(List<string> output)
        {
            for (int i = 0; i < this.Value; i++)
            {
                output.Add(this.Content);
            }
        }
    }
