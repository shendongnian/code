    <div class="panel-body">
        @if(_user.Movies.Any()) {
            <ul>
                @foreach (var _movie in _user.Movies.Where(x => x.ApplicationUserID == _user.Id)) 
                {
                    <li>@_movie.MovieName</li>
                }
            </ul>
        } 
        else 
        {
            <p>No movies...</p>
        }
    </div>
