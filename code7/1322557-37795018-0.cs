    @using Kendo.Mvc.UI
    @model IEnumerable<DFMS_MVC5.Models.DIM_LINKS>
    
    
        @(Html.Kendo().Grid<DFMS_MVC5.Models.DIM_LINKS>(Model)
        .Name("grid")
        .Columns(columns => {
            columns.Bound(p => p.ID_DIM_LINK);
            columns.Bound(p => p.LINK_NAME);
            columns.Bound(p => p.LINK_DESC);
            columns.Bound(p => p.CREATE_TIME_STAMP).Format("{0:MM/dd/yyyy}");
        })
        .Pageable()
        .Sortable()
        .Scrollable()
        .Filterable()
        .HtmlAttributes(new { style = "height:550px;" })
         )
