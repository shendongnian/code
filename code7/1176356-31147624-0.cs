    //Model
    public class DistrictViewModel
    {
	    public string name {get;set;}
	    public SelectList District {get;set;}
	    public int SelectedDistrict {get;set}
    }
    //Controller
    public class DistrictController : Controller
    {
     KUDEREntities db = new KUDEREntities();
	 
	 public ActionResult Index()
	 {
		var model = new DistrictViewModel();
		model.Districts = db.Districts.ToList();
		model.SelectedDistrict=0;
		return view(model);
	 }
	 
	 [HttpPost]
	 public ActionResult Search(int id)
	 {
		//do the search with the id of the selected district
		var data = db.Districts.Where(m=>m.leaId = id).FirstorDefault();//this would return the whole object.
		return Json(data, JsonRequestBehavior.AllowGet);
	 }	 
    }
    //Index View
    @Model DistrictViewModel
    <div>
    //with this your selector would be "#SelectedDistrict"
	@Html.DropDownListFor(model=>model.SelectedDistrict, new SelectList(Model.Districts,"leaId","name",Model.SelectedDistrict), new {@class=""})
	
	//with this your selector would be "#myList"
	//@Html.DropDownList("myList", new SelectList(ViewBag.districts, "leaId", "name", Model.SelectedDistrict)
    </div>
    <script>
    $(document).ready(function(){
	//when you want to search for the id selected, you just need to call the Search function below
	function Search() {
		//... now you have the value of the selecteditem 
        var parameters = { id: $("#SelectedDistrict").val() };
        $.ajax({
            type: 'post',
            url: '@Url.Action("Search", "District")',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            async: true,
            data: JSON.stringify(parameters),
            success: function (data) {
				//...do whatever with the data
            },
            failure: function (msg) {
                //... show a message of error
            }
        });
    }
    });
    </script>
