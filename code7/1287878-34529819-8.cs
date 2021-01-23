    foreach (var trend in @Model)
    {
       Html.RenderPartial("_Trend",trend);
       using(Html.BeginForm("Publish","Home"))
       {
         @Html.HiddenFor(s=>s.Name)
         @Html.HiddenFor(s=>s.TrendCode)
         @Html.ActionLink("Publish","Publish","Home",new { id=trend.Id},
                                                     new { @class="publishLink"})
       }
        
    }
