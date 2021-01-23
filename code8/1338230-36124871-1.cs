    @model Item
    
    <p>@Model.ItemName</p>
    <ul>
        @if (Model.Children != null && Model.Children.Count > 0)
        {
            foreach (var child in Model.Children)
            {
                <li>
                    @{Html.RenderPartial("Index", child);}
                </li>
            }
        }
    	else
    	{
    		<li>
    	    	No items available for @Model.ItemName.
    		</li>
    	}
    </ul>
