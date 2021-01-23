            [CollectionName("myCollection")]
			public abstract class DocumentBase
			{
				[BsonElement("elementA")]
				public DateTime ElementA { get; set; }
				
				[BsonElement("elementB")]
				public DateTime ElementB { get; set; }
                // I moved this to the SubDocument1 property
				[BsonElement("subDocument")]
				public SubDocumentBase SubDocumentBase { get; set; }
			}
			public class Document1 : DocumentBase
			{
                // I moved BsonElement here
                [BsonElement("subDocument")]
				public SubDocument1 SubDocument1 { get; set; }
			}
			public class SubDocument1 : SubDocumentBase
			{
				[BsonElement("elementC")]
				public string ElementC { get; set; }
			}
			
			[BsonIgnoreExtraElements]
			public class SubDocumentBase
			{
				[BsonElement("subElementA")]
				public string SubElementA { get; set; }
				[BsonElement("subElementB")]
				public string SubElementB { get; set; }
			}
