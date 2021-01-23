           url: "Search.aspx/DoSearch",
           data: '{"searchText":"' + searchText + '"}',
    		
    		
    		
    		
    		//Add this on code behind page...
    		using System.Web.Services;
    		
    		
    		
    		[WebMethod]
            public static void DoSearch(String searchText)
            {
    		//Do your stuff!!
    		}
