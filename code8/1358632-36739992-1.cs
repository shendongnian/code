    <legend class="legend">Tous Les Projets</legend>
    @{
        Layout = "~/Views/Shared/admin.cshtml";
    }
    <link href="~/Content/Gridmvc.css" rel="stylesheet" />
    <script src="~/Scripts/gridmvc.js"></script>
    <script src="~/Scripts/gridmvc.min.js"></script>
    <div class="container-fluid placeholders">
        <div style="height:850px">
            @(Html.Kendo().Grid<mvc_depences.Models.Projet>()
            .Name("grid")
            .Columns(columns =>
            {
                columns.Bound(c => String.Format("{0} {1}", c.Prenom, c.Nom)).Title("Chef de Projet").Width(145);
                columns.Bound(c => c.nomP).Title("Nom Projet");
                columns.Bound(c => c.DateDebut).Title("Date Debut");
                columns.Bound(c => c.DateFinPrevue).Title("Date Fin Prevue");
                columns.Bound(c => c.DateFinReele).Title("Date Fin Réelle");
                columns.Bound(c => c.etat).Title("Etat");
                columns.Bound(c => c.Description).Title("Description");
                columns.Command(command => { command.Edit().Text("Modifier"); }).Width(150);   
            })
          .Editable(editable => editable.Mode(GridEditMode.PopUp))
          .Pageable()
          .Selectable(selectable =>
          {
              selectable.Mode(GridSelectionMode.Single);
              selectable.Type(GridSelectionType.Row);
          })
          .Filterable()
          .Scrollable()
          .DataSource(dataSource => dataSource
              .Ajax()
              .Model(model => model.Id(p => p.ProjetId))
              .Read(read => read.Action("Projet_Read", "Projet"))
              .Update(update => update.Action("Projet_Update", "Projet"))
          )
            )
        </div>
    </div>
