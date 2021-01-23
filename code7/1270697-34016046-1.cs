    foreach(var item in Model.Items.Select((x, i) => new {Index = i, Value = x}))
    {
        if (item.Index % 4 == 0)
        { 
            <div class="tab-@(item.Index/4)">  
        }
                
                <a>Item @(item.Index + 1)</a>
        if (item.Index % 4 == 0)
        { 
            </div>
        }
    } 
    // If the number of items has a remainder of 4, close the div tag
    if(Model.Items.Count %4 != 0)
    {
        @:</div>
    }
