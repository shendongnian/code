    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
	    class Comment
	    {
 		   public string CommentId {get; set;}
 		   public string  ParentCommentId {get; set;}
 		   public string  CommentText{get; set;}
		   public List<Comment> ChildComments { get; set; }
	    }
    public static void Main()
	{
		
		 List<Comment> comments = new List<Comment>()
            {
                new Comment () { CommentId = "1", CommentText = "Comment 1", ParentCommentId = ""},
                new Comment () { CommentId = "2", CommentText = "Comment 2", ParentCommentId = ""},
                new Comment () { CommentId = "3", CommentText = "Sub Comment 1", ParentCommentId = "1"},
					
                new Comment () { CommentId = "4", CommentText = "Sub Comment 3", ParentCommentId = "3"},
				new Comment () { CommentId = "5", CommentText = "Sub Comment 2", ParentCommentId = "2"}
               
            };
		
		
            var formattedList = GetChildComments(comments, "");
            Console.WriteLine(formattedList.Count()); //2
		    Console.WriteLine(formattedList[0].ChildComments.Count()); //1
			Console.WriteLine(formattedList[0].ChildComments[0].ChildComments.Count());//1
		    Console.WriteLine(formattedList[1].ChildComments.Count());//1
           
        }
        private static List<Comment> GetChildComments(List<Comment> comments, string parentCommentId)
        {
            return comments
                    .Where(c => c.ParentCommentId == parentCommentId)
                    .Select(c => new Comment { 
                       CommentId = c.CommentId, 
                                  CommentText = c.CommentText, 
                                  ParentCommentId = c.ParentCommentId, 
                                  ChildComments = GetChildComments(comments, c.CommentId) })
                    .ToList();
        }
    }
