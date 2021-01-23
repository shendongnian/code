    @using xx.Relacionamiento.Modelo.Bussiness.Entities.Enumeraciones;
    @using xx.Relacionamiento.Modelo.Bussiness.Entities;
    @using Kendo.Mvc.UI;
    
    @model PresupuestosGenerale
    @Html.HiddenFor(h => h.PresupuestoGeneralId)
    @Html.Hidden("Categoria",CategoriaEvento.xx.ToString())
    <div class="row">
    ...
