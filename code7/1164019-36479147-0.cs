    @(Html.Kendo().Grid<TariffDetailViewModel>()
      .Name("grd_Tariff")
      .Columns(columns =>
      {
          foreach(var commisionType in Model.CommissionTypes)
          {
              columns.Bound(typeof(double), "Commissions['" + commissionType.Name + "'].Value")
                  .Title(commissionType.Name);
          }
          columns.Command(c => { c.Edit().Text("Edit"); }).Width(200);
      })
