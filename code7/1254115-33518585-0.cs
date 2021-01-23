    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var elmahErrorList = new List<ElmahError>{
    			new ElmahError{ ErrorId = Guid.NewGuid(), Application = "Something",Message = "Hello World" , TimeUtc = DateTime.Now },
    				new ElmahError{ ErrorId = Guid.NewGuid(), Application = "Something Else",Message = "Another Message" , TimeUtc = DateTime.Now }
    		};
    		
    		var logEntryList = new List<LogEntry>{
    			new LogEntry{ ID = 1, SourceClass = "Something",Message = "Hello World" , LogDate = DateTime.Now },
    				new LogEntry{ ID = 1, SourceClass = "Something Else",Message = "Another Message" , LogDate = DateTime.Now }
    		};
    		
    		var internalErrorsList = new List<InternalErrors>();
    		
    		var elmahErrorListinternalErrorses = elmahErrorList.Select(e => new InternalErrors
    																   {
    																	   Id = e.ErrorId.ToString(),
    																	   Application = e.Application,
    																	   Message = e.Message,
    																	   Type = e.Type,
    																	   User = e.User,
    																	   Date = e.TimeUtc,
    																	   StatusCode = e.StatusCode,
    																	   AllXml = e.AllXml,
    																	   Sequence = e.Sequence
    																   });
    		
    		internalErrorsList.AddRange(elmahErrorListinternalErrorses);
    		
    		var elmahErrorListlogEntryLists = logEntryList.Select(l => new InternalErrors
    															  {
    																  Id = l.ID.ToString(),
    																  Priority = l.Priority,
    																  Application = l.SourceClass,
    																  Message = l.Message,
    																  Type = l.Category,
    																  User = l.UserID,
    																  Date = l.LogDate
    															  });
    		internalErrorsList.AddRange(elmahErrorListlogEntryLists);
    		
    		internalErrorsList.ForEach(f =>
    								   {
    									   Console.Write(f.Id); Console.Write("\t");
    									   Console.Write(f.Application);Console.Write("\t");
    									   Console.Write(f.Message);Console.Write("\t");
    									   Console.Write(f.Date);Console.Write("\t");
    									   Console.WriteLine();
    								   });
    		
    	}
    	public class InternalErrors
    	{
    		public string Id { get; set; } //L:ID && E:ErrorId
    		public int Priority { get; set; } //L:Priority
    		public string Application { get; set; } //L:SourceClass && E:Application
    		public string Message { get; set; } //L:Message && E:Message
    		public string Type { get; set; } //L:Category && E:Type
    		public string User { get; set; } //L:UserID && E:User
    		public string ProcessID { get; set; } //L:ProcessID
    		public DateTime Date { get; set; } //L:LogDate && E:TimeUtc
    		public int StatusCode { get; set; } //E:StatusCode
    		public string AllXml { get; set; } //E:AllXml
    		public int Sequence { get; set; } //E:Sequence
    		public int ErrorCount { get; set; } //E:ErrorCount
    	}
    	public class ElmahError
    	{
    		public System.Guid ErrorId { get; set; }
    		public System.String Application { get; set; }
    		public System.String Host { get; set; }
    		public System.String Type { get; set; }
    		public System.String Source { get; set; }
    		public System.String Message { get; set; }
    		public System.String User { get; set; }
    		public System.Int32 StatusCode { get; set; }
    		public System.DateTime TimeUtc { get; set; }
    		public System.Int32 Sequence { get; set; }
    		public System.String AllXml { get; set; }
    	}
    	
    	public class LogEntry
    	{
    		public Int64 ID { get; set; }
    		public DateTime LogDate { get; set; }
    		public Int16 Priority { get; set; }
    		public string SourceClass { get; set; }
    		public string Category { get; set; }
    		public string Message { get; set; }
    		public string UserID { get; set; }
    		public string ProcessID { get; set; }
    	}
    }
