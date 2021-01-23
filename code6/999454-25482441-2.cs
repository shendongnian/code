    @Html.HiddenFor(model=>model.ID)
    @(Html.Kendo().Grid(Model.ContractCurrencyClauses)
                   .Name("ContractCurrencyClauses")
                   .ToolBar(toolbar => toolbar.Create())
                   .Columns(columns => {
                            columns.Bound(u => u.CONTRACT_ID).Hidden(true);
                            columns.Bound(u => u.CURRENCY);
                            columns.Bound(u => u.RATE);
                            columns.Command(command => { command.Edit(); command.Destroy(); });
                            })
    
                            .Editable(editable => editable.Mode(GridEditMode.InLine))
                            .DataSource(dataSource => 
                                    dataSource.Ajax()
                                    .Model(model =>
                                    {
                                        model.Id(u => u.CONTRACT_ID);
                                        //model.Id(u => u.CURRENCY);  Kendo datasource does not support composite data keys.  
                                         model.Field(u => u.CONTRACT_ID).DefaultValue(Model.ID);
                                    })
                             .Create(create => create.Action("Create", "Contracts"))
                             .Update(update => update.Action("Update", "Contracts"))
                             .Destroy(destroy => destroy.Action("DestroyCurClause", "Contracts")))
                    )
     
