    @(Html.Kendo().ComboBox()
                                    .Name("ChildAccountCode")
                                    .DataTextField("ChildAccountCode")
                                    .Filter(FilterType.Contains)
                                    .MinLength(3)
                                    .Placeholder("Select ChildAccountCode")
                                    .DataValueField("AccountName")
                                    .HtmlAttributes(new { @style = "width: 200px;" })
                                    .AutoBind(false)
                                    .Events(e =>
                                        {
                                            e.Change("onSelectCAO");
                                        })
                                                        .DataSource(source =>
                                                                    {
                                                                        source.Read(read =>
                                                                            {
                                                                                read.Action("ddlChildAccountCode", "Dropdowns").Data("AccountCodeParameter");
                                                                            });
                                                                    })                                                                                       
                 )
 
