    @model List<TabModel>
    
    @{
        <ul>
            @foreach (var item in Model)
            {
                <li>
                    <a>@item.TabName</a>
                    @if (item.Subs != null)
                    {
                        <ul>
                            @foreach (var subItem in item.Subs)
                            {
                                <li>
                                    <a>@subItem.SubTabName</a>
                                </li>
                            }
                        </ul>
                    }
                </li>
            }
        </ul>
    }
