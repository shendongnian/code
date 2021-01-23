    @model IEnumerable<object>
    @{
    var places = Model.ToList()[0];
    HypothesisWebMVC.Models.Place place = Model.ToList()[1] as HypothesisWebMVC.Models.Place;
    ViewBag.Title = "Create";
    }
    <script type="text/javascript">
    //Users data
    var json = @Html.Raw(Json.Encode(places));
    console.log("Places test " + json);
    </script>
