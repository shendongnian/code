	public ActionResult Index()
		{
			DataContext dt = new DataContext();
			Dropdown res = dt.Bind_Dropdown();
			IList <SelectListItem> selectList = new List<SelectListItem>();
			for (int i = 0; i < res.drpname.Count; i++)
			{
				var selectListItem = new SelectListItem
				{
					Value = res.drpid[i],
					Text = res.drpname[i]
				};
				selectList.Add(selectListItem);
			}
			res.items = new SelectList(selectList, "Value", "Text");
			return View("Index", res);
		}
