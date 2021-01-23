    @model WhenToUseRenderActionAndRenderPartial.Models.ShowPostViewModel
    @{
        ViewBag.Title = Model.Post.Title;
    }
     
    <section>
        <article>
            <header>
                <h1>@Model.Post.Title</h1>       
            Posted on | <time datetime="@Model.Post.DatePublished.ToString("s")">
               @Model.Post.DatePublished.ToLongDateString()
            </time> | @Model.Comments.Count() Comments
            </header>
            @Html.Raw(Model.Post.Content)
        </article> 
    </section>
    @{Html.RenderPartial("_Comments", Model.Comments);}
