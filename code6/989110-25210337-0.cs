    
    private static void GenerateThumbsAndImages()
		{
			foreach (Page i in CurrentContentInfo.Pages.Values)
			{
				PageImages.Add(new Uri(i.image));
				PageThumbs.Add(new Uri(i.thumb));
			}
		}
