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
