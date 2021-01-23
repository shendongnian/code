    @{ var index = 0; }
    @foreach(var items in Model.GroupBy(m=>m.GroupID).Select(g=>g.ToList())){
       Html.TextBox("items[" + index + "].Name", items.Name);
       Html.TextBox("items[" + index + "].GroupID", items.GroupID);
       index++;
    }
