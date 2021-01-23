    @(Html.Kendo().Grid<BookViewModel>()
            .Name("booksGrid")
            .Columns(column =>
            {
                column.Bound(m => m.Name);
                column.Bound(m => m.Culture).ClientTemplate("#=Culture.NativeName#").EditorTemplateName("CultureSelectorTemplate");
            })
            .ToolBar(toolBar =>
            {
                toolBar.Create();
                toolBar.Save();
            })
            .Sortable()
            .Pageable(pageable => pageable
                .Refresh(true)
                .PageSizes(true)
                .ButtonCount(10)
            )
            .HtmlAttributes(new { style = "border-style: double; border-width: 5px" })
            .Editable(e => e.Mode(GridEditMode.InCell))
            .DataSource(dataSource => dataSource
                .Ajax()
                .PageSize(20)
                .ServerOperation(false)
                .Model(m =>
                {
                    m.Id(f => f.BookId);
                    m.Field(f => f.Name);
                    m.Field(f => f.Culture).DefaultValue(ViewData["defaultCulture"] as CultureViewModel);//new SelectListItem() { Text = "English", Value = "en" });
                })
                .Create(create => create.Action("CreateBooks", "Books"))
                .Read(read => read.Action("ReadBooks", "Books"))
                .Update(update => update.Action("UpdateBooks", "Books"))
                .Destroy(destroy => destroy.Action("DeleteBooks", "Books"))
            )
            .Events(e => e.DataBound("onGridDataBound"))
        )
