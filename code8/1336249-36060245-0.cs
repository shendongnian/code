    @model IEnumerable<MyBlog.Areas.Admin.ViewModels.UserEntity>
    
    <h1>Admin Users</h1>
    
    <ul>
        @foreach (var user in Model)
        {
            <li>@user.Username</li>
        }
    </ul>
