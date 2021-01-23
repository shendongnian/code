    @{Dictionary<int, string> images = (Dictionary<int, string>)ViewBag.Images;
    @for (int i = 0; i < Model.Count(); i += 3)
    {
        <div class="row">
            @foreach (var item in Model.Skip(i).Take(3))
            {
                <div class="col-md-4 portfolio-item">
                    <a href="@Url.Action("Details", "Post", new { urlslug = item.UrlSlug })">
                        <img class="img-responsive" src="@Html.Raw("data:image/jpeg;base64," + images.Single(image => image.Key == item.ID).Value)" alt="">
                    </a>
                    <h3>
                        <a href="@Url.Action("Details", "Post", new { urlslug = item.UrlSlug })">@Html.DisplayFor(modelItem => item.Title)</a>
                    </h3>
                    <p>@Html.DisplayFor(modelItem => item.ShortDescription)</p>
                    @Html.ActionLink("Edit", "Edit", new { id = item.Id }) |
                    @Html.ActionLink("Details", "Details", new { urlslug = item.UrlSlug }) |
                    @Html.ActionLink("Delete", "Delete", new { id = item.Id })
                </div>
            }
        </div>
      }
    }
