     foreach (var paragraph in document.MainDocumentPart.Document.Descendants<Paragraph>())
     {
          foreach (var run in paragraph.Elements<Run>())
          {
             var item = run.Elements<Text>().FirstOrDefault(b => b.Text.Contains("DTT"));
             if (item != null)
             {
               if (document.MainDocumentPart.GetPartsCountOfType<WordprocessingCommentsPart>() > 0)
               {
                  comments = document.MainDocumentPart.WordprocessingCommentsPart.Comments;
                  commentsEx = document.MainDocumentPart.WordprocessingCommentsExPart.CommentsEx;
                  if (comments.HasChildren)
                  {
                       // Obtain an unused ID.
                       id = comments.Descendants<Comment>().Select(e => e.Id.Value).Max();
                  }
             }
             else
             {
                 // No WordprocessingCommentsPart part exists, so add one to the package.
                 WordprocessingCommentsPart commentPart = document.MainDocumentPart.AddNewPart<WordprocessingCommentsPart>();
                 commentPart.Comments = new Comments();
                 comments = commentPart.Comments;
                 WordprocessingCommentsExPart commentsExPart = document.MainDocumentPart.AddNewPart<WordprocessingCommentsExPart>();
                 commentsExPart.CommentsEx = new CommentsEx();
                 commentsEx = commentsExPart.CommentsEx;
            }
            Comment comment1 = new Comment() { Initials = "GS", Author = "Tony, Stark", Date = System.Xml.XmlConvert.ToDateTime("2018-11-19T14:54:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind), Id = "1" };
            Paragraph paragraph1 = new Paragraph() {  ParagraphId = "68DAFED3", TextId = "77777777" };               
           paragraph1.Append(new Run(new Text("fsdfas")));
           comment1.Append(paragraph1);
           Comment comment2 = new Comment() { Initials = "GS", Author = "Tony, Stark", Date = System.Xml.XmlConvert.ToDateTime("2018-11-19T14:54:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind), Id = "2" };
           Paragraph paragraph2 = new Paragraph() { ParagraphId = "346EE35B", TextId = "77777777" };                          
           paragraph2.Append(new Run(new Text("sadfsad")));
           comment2.Append(paragraph2);
           comments.Append(comment1);
           comments.Append(comment2);
           comments.Save();
           CommentRangeStart commentRangeStart1 = new CommentRangeStart() { Id = "1" };
           CommentRangeStart commentRangeStart2 = new CommentRangeStart() { Id = "2" };
           CommentRangeEnd commentRangeEnd1 = new CommentRangeEnd() { Id = "1" };
           CommentReference commentReference1 = new CommentReference() { Id = "1" };
           CommentRangeEnd commentRangeEnd2 = new CommentRangeEnd() { Id = "2" };
           CommentReference commentReference2 = new CommentReference() { Id = "2" };
           run.InsertBefore(commentRangeStart1, item);
           run.InsertBefore(commentRangeStart2, item);
           var cmtEnd = run.InsertAfter(commentRangeEnd1, item);
           var cmtEnd2 = run.InsertAfter(commentRangeEnd2, cmtEnd);
           run.InsertAfter(new Run(commentReference1), cmtEnd);
           run.InsertAfter(new Run(commentReference2), cmtEnd2);
           CommentEx commentEx1 = new CommentEx() { ParaId = "68DAFED3", Done = false };
           CommentEx commentEx2 = new CommentEx() { ParaId = "346EE35B", ParaIdParent = "68DAFED3", Done = false };
           commentsEx.Append(commentEx1);
           commentsEx.Append(commentEx2);
           commentsEx.Save();
           }
        }
    }
