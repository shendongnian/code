	[HttpPost]
	[ValidateAntiForgeryToken]
	[AllowAnonymous]
    [ValidateInput(false)]
	public async Task<ActionResult> CreatePost(BlogViewModel blog, string returnUrl)
	{
		if (ModelState.IsValid)
		{
			try
			{
				await Task.Run(new Action( blog.CreatePost ) );
				//blog.CreatePost();
				if (blog.BlogID > 0)
				{
					ViewBag.Message = blog.Message;
				}
				else
				{
					ViewBag.Message = "Problem Posting new content";
				}
			}
			catch (Exception ex)
			{
				ViewBag.Message = "Problem Posting Content: '" + ex.Message;
			}
		}
		return PartialView("PopupMessage");
	}//end CreatePost
