    @model IEnumerable<WebApplication1.Models.WikiPage>
    @using (Html.BeginForm("DeletePages", "Home", FormMethod.Post))
    {
     <ul>
        @foreach (var item in Model)
        {
            <li>
                <label>@item.Title
                    <input type="checkbox" name="titles" value="@item.Title />
                </label>
            </li>
        }
    </ul>
    <input type="submit" value="Delete pages" />
    }
