    @(Html.Kendo().Grid<CustomerAnimalViewModel>()
                        .Name(gridId)
                        .HtmlAttributes(new { @class = "grid" })
                        .Columns(columns =>
                        {
                            columns.Bound(c => c.AnimalId).Visible(false);
                            columns.Bound(c => c.RegistrationNumber).ClientTemplate("<a class='active' href=javascript:viewAnimal(\"" + "#: AnimalId #" + "\",\"" + "#=escape(Name) #" + "\")  >#: RegistrationNumber #</a>");
                            columns.Bound(c => c.Type);
                            columns.Bound(c => c.Prefix);
                            columns.Bound(c => c.Name);
                            columns.Bound(c => c.DateOfBirth).ClientTemplate("#= kendo.toString(DateOfBirth == null ? '' : DateOfBirth, '" + Constants.DateFormat + "') #");
                            columns.Bound(c => c.Sex);
                            columns.Bound(c => c.HMC);
                            columns.Bound(c => c.Usability).Visible(false);
                            columns.Bound(c => c.Status);
                            columns.Command(command => { command.Destroy(); }).Title(Resources.Actions);
                        })
                        .DataSource(dataSource => dataSource
                            .Ajax()
                            .Sort(x=>x.Add("DateOfBirth").Ascending())
                            .Model(model =>
                            {
                                model.Id(p => p.AnimalId);
                                model.Field(p => p.RegistrationNumber);
                                model.Field(p => p.Type);
                                model.Field(p => p.Prefix);
                                model.Field(p => p.Name);
                                model.Field(p => p.Status);
                                model.Field(p => p.Sex);
                                model.Field(p => p.HMC);
                                model.Field(p => p.Usability);
                                model.Field(p => p.Status);
                            })
                            .Read(read => read.Action("ReadTypes", "Customer").Data("filterData"))
                            .Destroy(destroy => destroy.Action("DeleteAnimal", "Customer"))
                        )
                        .Navigatable()
                        .Sortable()
                        .Filterable()
                        .Pageable()
        
                   )
