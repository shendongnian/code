     @(Html.Kendo().Grid<Kendo.Mvc.Examples.Models.ProductViewModel>()
            .Name("grid")
            .Columns(columns =>
            {
                columns.Bound(p => p.ProductName).Title("Product Name");
                columns.Bound(p => p.UnitPrice).Title("Unit Price");
                columns.Bound(p => p.UnitsInStock).Title("Units In Stock");
            })
            .Events(events => events.DataBound("onGridDataBound"))
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("Products_Read", "Grid"))
             )
        )
    <script>
      function onGridDataBound(e){
        var grid = e.sender;
        
        if (grid.dataSource.total() == 0 ){
        //Hide grid
          $(grid).hide();
        }
        else{
          //Show grid
          $(grid).show();
        }
      }
      
    </script>
