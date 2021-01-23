	public class PostRepository
	{
		string PublicationID;
		string Title;
		
		public virtual NewsFeed GetNewsFeed()
		{
			return new NewsFeed { Id = PublicationID, Title = Title };
		}
	}
	public class AlbumRepository : PostRepository
	{
		AlbumPhoto[] AlbumPhoto;
		
		public override NewsFeed GetNewsFeed()
		{
			NewsFeed newsFeed = base.GetNewsFeed();
			newsFeed.AlbumPhotoPath = AlbumPhoto.Where(...);
			return newsFeed;
		}
	}
