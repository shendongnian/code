    @using System.Data
    @{
        ViewBag.Title = "Index";
    
    
        DataTable ds = ViewBag.Units as DataTable;
        var rows = from x in ds.AsEnumerable()
                   select new
                   {
                       id = x.Field<int>("ID"),
                       name = x.Field<string>("name")
                   };
    }
    <div class="form-horizontal">
        <h4>
            Select your favourite Name</h4>
        @foreach (var item in rows)
        {  
            <input id="chk_@(item.name)"   type="checkbox"  value="@item.id"   />
            @item.name <br />  
        }
    </div>
