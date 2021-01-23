        @(Html.Kendo().ComboBox()
                  .Name("EingangDrop")
                  .Placeholder("Eingang durch...")
                  .DataTextField("WSText")
                  .DataValueField("ID")
                  .HtmlAttributes(new { ng_model="Modell.EingangDurch" })
                  .Filter("contains")
                  .AutoBind(false)
                  .MinLength(3)
                  .DataSource(source =>
                  {
                      source.Read(read =>
                      {
                          read.Action("GetVersand", "UserApi");
                      })
                      .ServerFiltering(false);
                  })
                 .Events(e =>
                 {
                    e.Change("onChange");
                 })
            )
