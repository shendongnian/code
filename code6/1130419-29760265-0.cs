    @model MyBlogger.ViewModel.PostsViewModel
    @{
        ViewBag.Title = "EditPostTag";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    <h2>EditPostTag</h2>
    @using (Html.BeginForm()) // add this
    {
        ....
    }
