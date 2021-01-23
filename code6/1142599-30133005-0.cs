    @if (Model.CATEGORIES.Where(s => s.TAB_ITEM_PARENT_ID ==     Model.TAB_ITEM_CHILD_ID).Any())
    {
    foreach (var node in Model.CATEGORIES)
    {
        if (node.TAB_ITEM_PARENT_ID == Model.TAB_ITEM_CHILD_ID)
        {
            SeededCategories inner = new SeededCategories { TAB_ITEM_CHILD_ID = node.TAB_ITEM_ID, CATEGORIES = Model.CATEGORIES };
            bool hasChildren = Model.CATEGORIES.Any(x => x.TAB_ITEM_PARENT_ID == node.TAB_ITEM_ID);
            bool hasParents = Model.CATEGORIES.Any(x => x.TAB_ITEM_ID == node.TAB_ITEM_PARENT_ID);
            <li>
                @if (hasChildren && !hasParents)
                {
                    <a href="#"><span><i class="@node.ICON"></i> @node.TAB_ITEM_NAME</span></a>
                }
                else if (hasChildren && hasParents)
                {
                    <a href="@node.URL"><span><i class="fa fa-toggle-right"></i> @node.TAB_ITEM_NAME</span></a>
                }
                else
                {
                    <a href="@node.URL"><span><i class="#"></i> @node.TAB_ITEM_NAME</span></a>
                }
                @if (hasChildren)
                {
                    <ul>
                        @Html.Partial("_TreeCategories", inner)
                    </ul>
                }
            </li>
        }
      }
    }
