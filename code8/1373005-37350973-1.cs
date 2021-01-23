	[Authorize()]
	public IActionResult SearchItems(string searchString)
	{
		var ItemList = from i in _context.ItemModel
						select new ItemDisplay
						{
							m_ItemID = i.ID,
							m_ItemDesc = i.Description,
							m_CategoryName = i.SubCategory.Category.CategoryName,
							m_ManfName = i.Manufacturer.Name,
							m_SubCategoryName = i.SubCategory.SubCategoryName,
						};
		// Apply filter if search query was entered
		if (!String.IsNullOrEmpty(searchString))
		{
			// Sanitize search string
			searchString = searchString.Trim();
			searchString = System.Text.RegularExpressions.Regex.Replace(searchString, @"[^0-9a-zA-Z\._\s]", " ");
			searchString = System.Text.RegularExpressions.Regex.Replace(searchString, @"[\s]+", " ");
			string[] searchWords = searchString.Split(' ');
			foreach (var word in searchWords)
			{
				ItemList = ItemList.Where(s => s.m_ItemDesc.Contains(word) ||
							   s.m_ManfName.Contains(word) ||
							   s.m_CategoryName.Contains(word) ||
							   s.m_SubCategoryName.Contains(word)
							);
			}
		}
		ItemList = ItemList.OrderBy(r => r.m_ItemDesc);
		return View(ItemList);
	}
