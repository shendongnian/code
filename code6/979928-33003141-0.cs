    @{
        var pageSize = 8;
        if(Model.Content.HasValue("numberOfItemsPerPage")){
        pageSize = Model.Content.GetPropertyValue<int>("numberOfItemsPerPage");}
        var page = 1; int.TryParse(Request.QueryString["page"], out page);
        var items = Umbraco.TypedContent(Model.Content.Id).Children.Where(x => x.DocumentTypeAlias == "exampleAlias" && x.IsVisible()).OrderByDescending(x => x.CreateDate);
        var totalPages = (int)Math.Ceiling((double)items.Count() / (double)pageSize);
        if (page > totalPages)
        {
            page = totalPages;
        }
        else if (page < 1)
        {
            page = 1;
        }
        foreach (var item in items.Skip((page - 1) * pageSize).Take(pageSize)
        {
            <div class="example-div">
                <h2>@item.GetPropertyValue("example")</h2>
            </div>
        }
       if (totalPages > 1)
       {
           <div class="pagination">
               <ul>
                   @if (page > 1)
                   {
                       <li><a href="?page=@(page-1)">Prev</a></li>
                   }
                   @for (int p = 1; p < totalPages + 1; p++)
                   {
                       <li class="@(p == page ? "active" : string.Empty)">
                           <a href="?page=@p">@p</a>
                       </li>
                   }
                   @if (page < totalPages)
                   {
                       <li><a href="?page=@(page+1)">Next</a></li>
                   }
               </ul>
           </div>
        }
    }
