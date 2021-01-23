	public class CookieReplicatingWebClient : WebClient
	{
		protected override WebRequest GetWebRequest(Uri address)
		{
			var request = (HttpWebRequest)base.GetWebRequest(address);
			if (request != null)
			{
				HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
				CookieContainer cookieContainer = new CookieContainer();
				for (int i = 0; i < cookies.Count; i++)
				{
					// Clone cookies
					HttpCookie httpCookie = cookies[i];
					if (httpCookie != null)
					{
						cookieContainer.Add(new Cookie { Domain = request.RequestUri.Host, Name = httpCookie.Name, Path = httpCookie.Path, Secure = httpCookie.Secure, Value = httpCookie.Value });
					}
				}
				request.CookieContainer = cookieContainer;
			}
			return request;
		}
	}
    protected void Page_Load(object sender, EventArgs e)
	{
		using (WebClient client = new CookieReplicatingWebClient())
		{
            // Request secured area (of Kentico's Corporate sample site)
			string htmlCode = client.DownloadString("http://localhost/Kentico82/Partners/Gold-partners.aspx");
		}
	}
