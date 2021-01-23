	using Microsoft.SharePoint.Client;
	using SP = Microsoft.SharePoint.Client;
	using System.Net;
	namespace SharePointSetMetaInfo
	{
		class Program
		{
			static void Main(string[] args)
			{
				using (ClientContext context = new ClientContext("https://mySharePointServer/sites/MySite/"))
				{
					context.Credentials = new NetworkCredential("myUserName", "myPassword", "MYDOMAIN");
					SP.List calendarList = context.Web.Lists.GetByTitle("Calendar");
					ListItem cListItem = calendarList.GetItemById(2301);//This is one way to retrieve an item for update. You can also use a Caml Query
					context.Load(cListItem);
					cListItem["MetaInfo"] = "Categories:SW|Red Category\r\n";
					cListItem.Update();
					context.ExecuteQuery();
				}
			}
		}
	}
