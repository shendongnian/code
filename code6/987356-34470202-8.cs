    @using PagedList.Mvc;
    @using PagedList; 
    
    @model IPagedList<Babywatcher.Core.Models.OrderViewModel>
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    <div class="container-fluid">
        <p>
            @Html.ActionLink("Create New", "Create")
        </p>
        @if (Model.Count > 0)
        {
          
    
            <table class="table">
              <tr>
                <th>
                    @Html.DisplayNameFor(model => model.First().orderId)
                </th>
                <!--rest of your stuff-->
            </table>
           
        }
        else
        {
            <p>No Orders yet.</p>
        }
        @Html.PagedListPager(Model, page => Url.Action("Index", new { page }))
    </div>
