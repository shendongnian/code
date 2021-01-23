    public class CommentingAuthorComparer : IEqualityComparer<CommentingAuthor>
    {
        public bool Equals(CommentingAuthor author, CommentingAuthor author2)
        {
            return author.PostAuthorName.Equals(author2.PostAuthorName);
        }
    
        public int GetHashCode(CommentingAuthor author)
        {
            return author.PostAuthorName.GetHashCode();
        }
    }
