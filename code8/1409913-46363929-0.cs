                        Html.Kendo().DropDownList()
                            .Name("ddlstrings")
                            .ValuePrimitive(true)
                            .SelectedIndex(0)
                            .DataSource(source =>
                                {
                                    source.Read(read =>
                                    {
                                        read.Action("getData", "String");
                                    });
                                })
