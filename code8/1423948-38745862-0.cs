    <div class="row">
        @if (HttpRuntime.Cache["ProjectId"] != null)
        {
            var loggedOnUsers = HttpRuntime.Cache["ProjectId"] as Dictionary<string, DateTime>;
            <span> Online Users: </span>
            if (loggedOnUsers != null)
            {
                foreach (var userItem in loggedOnUsers.Keys)
                {
                    <p>@userItem <span>@loggedOnUsers[userItem]</span></p>
                }
            }
            else
            {
                <p>No users!</p>
            }
           
        }
    </div>
