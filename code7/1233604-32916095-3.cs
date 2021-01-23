	public bool DeleteNews(string id)
	{
		using (EF.ServiceDBEntities context = new EF.ServiceDBEntities())
		{
			var n = context.News.FirstOrDefault(x => x.NewsID == int.Parse(id));
			if (n != null)
			{
				context.News.Remove(n);
				context.SaveChanges();
                return true;
			}
		}
        return false;
	}
