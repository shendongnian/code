	void Main()
	{
		var xml = @"<story id=""485432424"">
		  <link type=""html"">http://www.npr.org/2016/07/10/485432424/with-administrative-corruption-in-afghanistan-u-s-troops-presence-won-t-make-any?ft=nprml&amp;f=1149</link>
		  <link type=""api"">http://api.npr.org/query?id=485432424&amp;apiKey=MDIxNjY4ODAwMDE0NTAxMjAwODQ4ZTA1Nw000</link>
		  <link type=""short"">http://n.pr/29EFodu</link>
		  </story>";
	
		using (var reader = new StringReader(xml))
		{
			var stories = new List<Story>();
			var xDoc = XDocument.Load(reader);
			foreach (var storyElement in xDoc.Elements("story"))
			{
				var story = new Story();
				foreach (var linkElement in storyElement.Elements("link"))
	            {
					var value = linkElement.Attribute("type").Value;
					if (value == "html")
						story.Html = linkElement.Value;
					else if (value == "api")
						story.Api = linkElement.Value;
					else if (value == "short")
						story.Short = linkElement.Value;
				}
				stories.Add(story);
			}
			// process stories;
		}
	}
	
	public class Story
	{
		public string Html { get; set; }
		public string Api { get; set; }
		public string Short { get; set;}
	}
