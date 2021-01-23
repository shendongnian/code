    public class FakePostsDbSet : FakeDbSet<Post>
    {
        public override Post Find(params object[] keyValues)
        {
            return this.SingleOrDefault(
                post => post.Slug == (string) keyValues.Single());
        }
    }
