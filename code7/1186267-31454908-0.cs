    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player() { Id = 102, FirstName = "Danny", LastName = "TopScorer", AverageGoalsPerGame = 3.5, TotalGoalsScored = 150 };
    
            XmlSerializer serializer = new XmlSerializer(typeof(Player));
            XmlWriterSettings settings = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true, Encoding = Encoding.UTF8 };
            StringBuilder output = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(output, settings);
            
            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, player, xns);
            
            Console.WriteLine(output.ToString());
            Console.ReadLine();
        }
    }
    
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalGoalsScored { get; set; }
        public double AverageGoalsPerGame { get; set; }
    }
