    @model IEnumerable<WebApplication2.Models.Rec>
    
    <h2>_select_recs</h2>
    <ul>
        @foreach (var item in Model)
        {
            <li>@item.RecTitle</li>
        }
    </ul>
