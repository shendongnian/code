    @(Html.Kendo().Grid(Model.bar)//the grid is now working with the list
                  .Name("Grid")
                  .Columns(columns => {
                      columns.Bound(e => e.Item1);//first item in tuple
                      columns.Bound(e => e.Item2);//second item in tuple
                      columns.Command(command => {
                        command.Edit();
                        command.Destroy();
                      }).Width("30%");
                  })
