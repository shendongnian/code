      @(Html.Kendo().Grid(Model.ContractCurrencyClauses)
                              .Name("ContractCurrencyClauses")
                              .ToolBar(toolbar => { toolbar.Create(); })
                              .Columns(columns => {
                                  columns.Bound(p => p.CONTRACT_ID).Hidden().ClientTemplate("#= CONTRACT_ID #" +
                                    "<input type='hidden' name='ContractCurrencyClauses[#= index(data)#].CONTRACT_ID' value='#= CONTRACT_ID #' />"
                                  );                                  
                                  columns.Bound(p => p.CURRENCY).ClientTemplate("#= CURRENCY #" +
                                   "<input type='hidden' name='ContractCurrencyClauses[#= index(data)#].CURRENCY' value='#= CURRENCY #' />"
                                  ).EditorTemplateName("CurrencyDDL");
                                  
                                  columns.Bound(p => p.RATE).ClientTemplate("#= RATE #" +
                                   "<input type='hidden' name='ContractCurrencyClauses[#= index(data)#].RATE' value='#= RATE #' />"
                                  );
                                  columns.Command(command => { command.Destroy(); });
                              })
                            .Editable(editable => editable.Mode(GridEditMode.InCell).CreateAt(GridInsertRowPosition.Bottom))
                            .DataSource(dataSource => 
                                dataSource.Ajax()
                                .Model(model =>
                                {
                                    model.Id(u => u.CONTRACT_ID);
                                    model.Field(u => u.CONTRACT_ID).DefaultValue(Model.ID);                                   
                                })
                                .ServerOperation(false)
                                )
                )
    <script>
        function index(dataItem) {
            var data = $("#ContractCurrencyClauses").data("kendoGrid").dataSource.data();
            return data.indexOf(dataItem);
        }
    </script>
