	void Main()
	{
		var serializer = new DataContractSerializer(typeof(IProductDescription),  knownTypes: new[] { typeof(ProductDescription) });
		
		using(var writer = new XmlTextWriter("C:\\Temp\\test.xml", Encoding.UTF8))
		{
			serializer.WriteObject(writer, new ProductDescription());	
		}
		
		using(var reader = new XmlTextReader("C:\\Temp\\test.xml"))
		{
			var o = serializer.ReadObject(reader) as IProductDescription;
			
			Console.WriteLine(o.ToString());
		}
	}
	
	public enum ProductStatus { One, Two, Three }
	
	public interface IProductDescription
	{
		[DataMember]
		List<AssetDescription> Assets { get; set; }
	
		[DataMember]
		string ProductId { get; set; }
	
		[DataMember]
		string Description { get; set; }
	
		[DataMember]  
		string FormattedPrice { get; set; }
	
		[DataMember]
		DateTime? ExpirationDate { get; set; }
	
		[DataMember]
		ProductStatus ProductStatus { get; set; }
	
		[DataMember]
		string ProductPageUrl { get; set; }
	
		[DataMember]
		string PackageDownloadLocationUrl { get; set; }
	
	}
	
	[DataContract]
	public class ProductDescription : IProductDescription
	{
		[DataMember]
		public List<AssetDescription> Assets { get; set; }
	
		[DataMember]
		public string ProductId { get; set; }
	
		[DataMember]
		public string Description { get; set; }
	
		[DataMember]  
		public string FormattedPrice { get; set; }
	
		[DataMember]
		public DateTime? ExpirationDate { get; set; }
	
		[DataMember]
		public ProductStatus ProductStatus { get; set; }
	
		[DataMember]
		public string ProductPageUrl { get; set; }
	
		[DataMember]
		public string PackageDownloadLocationUrl { get; set; }
	
	}
		
	[DataContract]
	public class AssetDescription
	{
		[DataMember]
		public string Type { get; set; }
	
		[DataMember]
		public string Name { get; set; }
	
		[DataMember]
		public string Description { get; set; }
	
		[DataMember]
		public string IconUrl { get; set; }
	
	}
