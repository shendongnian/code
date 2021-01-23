	[DataContract]
	public class Ruling
	{
		[DataMember(Name = "date")]
		public string Date { get; set; }
		[DataMember(Name = "text")]
		public string Text { get; set; }
	}
	[DataContract]
	public class ForeignName
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "language")]
		public string Language { get; set; }
		[DataMember(Name = "multiverseid")]
		public int Multiverseid { get; set; }
	}
	[DataContract]
	public class Legality
	{
		[DataMember(Name = "format")]
		public string Format { get; set; }
		[DataMember(Name = "legality")]
		public string LLegality { get; set; }
	}
	[DataContract]
	public class Card
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "manaCost")]
		public string ManaCost { get; set; }
		[DataMember(Name = "cmc")]
		public int Cmc { get; set; }
		[DataMember(Name = "colors")]
		public IList<string> Colors { get; set; }
		[DataMember(Name = "type")]
		public string Type { get; set; }
		[DataMember(Name = "supertypes")]
		public IList<string> Supertypes { get; set; }
		[DataMember(Name = "types")]
		public IList<string> Types { get; set; }
		[DataMember(Name = "subtypes")]
		public IList<string> Subtypes { get; set; }
		[DataMember(Name = "rarity")]
		public string Rarity { get; set; }
		[DataMember(Name = "set")]
		public string Set { get; set; }
		[DataMember(Name = "text")]
		public string Text { get; set; }
		[DataMember(Name = "artist")]
		public string Artist { get; set; }
		[DataMember(Name = "number")]
		public string Number { get; set; }
		[DataMember(Name = "power")]
		public string Power { get; set; }
		[DataMember(Name = "toughness")]
		public string Toughness { get; set; }
		[DataMember(Name = "layout")]
		public string Layout { get; set; }
		[DataMember(Name = "multiverseid")]
		public int Multiverseid { get; set; }
		[DataMember(Name = "imageUrl")]
		public string ImageUrl { get; set; }
		[DataMember(Name = "watermark")]
		public string Watermark { get; set; }
		[DataMember(Name = "rulings")]
		public IList<Ruling> Rulings { get; set; }
		[DataMember(Name = "foreignNames")]
		public IList<ForeignName> ForeignNames { get; set; }
		[DataMember(Name = "printings")]
		public IList<string> Printings { get; set; }
		[DataMember(Name = "originalText")]
		public string OriginalText { get; set; }
		[DataMember(Name = "originalType")]
		public string OriginalType { get; set; }
		[DataMember(Name = "legalities")]
		public IList<Legality> Legalities { get; set; }
		[DataMember(Name = "id")]
		public string Id { get; set; }
	}
	[DataContract]
	public class ApiResult
	{
		[DataMember(Name = "card")]
		public Card Card { get; set; }
	}
