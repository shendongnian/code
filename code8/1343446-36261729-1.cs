            @model IEnumerable<Models.DashBoard>
            @{
                ViewBag.Title = "Dashboard";
            }
            
            <h2>Dashboard</h2>
            
            @foreach(var item in Model){
                <div>
                    <li>
                        @item.Name
                   </li>
                   <li>
                        @item.DeptID 
                   </li>
                   ....
                </div>
            }
