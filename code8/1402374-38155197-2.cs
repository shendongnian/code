	public class PublicationRepository
	{
		string PublicationID;
		string Title;
		
		public virtual NewsFeed GetNewsFeed()
		{
			return new NewsFeed { Id = PublicationID, Title = Title };
		}
	}
	public class PostRepository : PublicationRepository
	{
		string UserID;
		
		public virtual NewsFeed GetNewsFeed()
		{
			NewsFeed newsFeed = base.GetNewsFeed();
			newsFeed.OwnerIsMyManager = promoManagerIds.Contains(UserID);
			return newsFeed;
		}
	}
	public class AlbumRepository : PublicationRepository
	{
		AlbumPhoto[] AlbumPhoto;
		
		public override NewsFeed GetNewsFeed()
		{
			NewsFeed newsFeed = base.GetNewsFeed();
			newsFeed.AlbumPhotoPath = AlbumPhoto.Where(...);
			return newsFeed;
		}
	}
