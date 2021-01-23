	<ul id="filter">
		@{ 
			List<Nipo.Models.Entity.category_path> CategoryPaths = ViewData["Categories"] as List<Nipo.Models.Entity.category_path>;
			Nipo.Models.Entity.category CurrentCategory = ViewData["Category"] as Nipo.Models.Entity.category;
			Dictionary<int, List<int>> Parents = ViewData["Parents"] as Dictionary<int, List<int>>;
			int Counter = 0;
		}
		@foreach (var CategoryPath in CategoryPaths)
		{
			Nipo.Models.Entity.category_path Next = CategoryPaths.ElementAtOrDefault(Counter+1);
			bool IsActive = (CurrentCategory != null && CurrentCategory.id_category == CategoryPath.category.id_category);
			if (IsActive)
			{
				@Html.Raw("<li class=\"active\">")
			}
			else
			{
				@Html.Raw("<li>")
			}
			<a title="@CategoryPath.category.name">
				@CategoryPath.category.name
				<i class="fa fa-caret-right"></i>
				<i class="fa fa-caret-down"></i>
			</a>
			if (Next != null && Next.depth > CategoryPath.depth)
			{
				string Class = "";
				string Style = "";
				string Element = "<ul class=\"collapse ";
				if (IsActive)
				{
					Element += "in ";
				}
				Element += "\" ";
				if (Parents.ContainsKey(CategoryPath.category.id_category) && CurrentCategory != null && Parents[CategoryPath.category.id_category].Contains(CurrentCategory.id_category))
				{
					Element += "style=\"display: block\" ";
				}
				@Html.Raw(Element)
			} else if (Next != null && Next.depth < CategoryPath.depth)
			{
				for (var i = 0; i < (CategoryPath.depth - Next.depth); i++)
				{
						@Html.Raw("</ul></li>");
					}
				}
				else if (Next != null && Next.depth == CategoryPath.depth)
				{
					@Html.Raw("</li>");
				}
				else if (Next == null)
				{
					for (var i = 0; i < CategoryPath.depth; i++)
					{
						@Html.Raw("</ul></li>");
					}
			}
			Counter++;
		}
