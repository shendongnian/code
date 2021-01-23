	void Main()
	{
		var messages = new List<MessageModel>
		{
			new MessageModel(100,"1st title","1st content", 1,"User.pdf"),
			new MessageModel(100,"1st title","1st content",  2,"Log.txt"),
			new MessageModel(100,"1st title","1st content", 3,"manual.doc"),
			new MessageModel(101,"2nd title","2nd content", 4,"dummy.txt"),   
			new MessageModel(102,"3rd title","3rd content" ),
			new MessageModel(103,"3rd title","3rd content")
		};
		
		var groupedMessages = 
		messages.GroupBy(x=> new {x.MessageId, x.Title, x.Content})
				.Select(x=> new HistoryModel
			  				  {
							  	MessageId =  x.Key.MessageId,
								Title = x.Key.Title,
								Content = x.Key.Content,
								Files = new List<FileModel>(x.Where( f=>  f.FileId != null)
															 .Select( g => new FileModel(g.FileId,  g.FileName)))
							  });
		
		groupedMessages.Dump();
	}
	
	// Define other methods and classes here
	public class MessageModel
	{
		public int MessageId {get; set;}
		
		public string Title {get; set;}
		
		public string Content {get; set;}
		
		public int? FileId {get; set;}
		
		public string FileName {get; set;}
		
		public MessageModel(int id, string title, string content, int? fileId = null, string fileName= null)
		{
			MessageId = id;
			Title =  title;
			Content = content;
			FileId = fileId;
			FileName = fileName;
		}
	}
	
	public class HistoryModel
	{
		public int MessageId {get; set;}
		
		public string Title {get; set;}
		
		public string Content {get; set;}
		
		public List<FileModel> Files{get; set;} = new List<FileModel>();
		
	}
	
	public class FileModel
	{
		public int? FileId {get; set;}
		
		public string FileName {get; set;}
		
		public FileModel(int? id, string name)
		{
			FileId = id;
			FileName = name;
		}
	}
