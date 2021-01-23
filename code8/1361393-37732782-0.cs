            private void BuildCommentExtendXML(WordprocessingDocument document, string randomHexBinaryValue, HexBinaryValue commentsParagraphDescendantId)
        {
            var commentsEx = document.MainDocumentPart.WordprocessingCommentsExPart.CommentsEx;
            CommentEx commentEx = new CommentEx()
            {
                ParaId = randomHexBinaryValue,
                ParaIdParent = commentsParagraphDescendantId,
                Done = new OnOffValue(false)
            };
            commentsEx.Append(commentEx);
        }
