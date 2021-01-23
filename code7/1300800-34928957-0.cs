	 <i>
	 public class CmsCustomUrlRecordEntityNameRequested : IConsumer<CustomUrlRecordEntityNameRequested>
    {
	
		void HandleEvent(CustomUrlRecordEntityNameRequested eventMessage)
		{
								eventMessage.RouteData.Values["controller"] = "Topic";
								eventMessage.RouteData.Values["action"] = "TopicDetails";
								eventMessage.RouteData.Values["topicId"] = urlRecord.EntityId;
								eventMessage.RouteData.Values["SeName"] = urlRecord.Slug;
		}
	
	}
	
	</i>
