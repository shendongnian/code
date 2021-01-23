    public class MyStatsModel
    {
         public int StatA { get; set; }
         public string StatB { get; set; }
         public double StatC { get; set; }
         // etc
    }
    [HttpGet]
    public JsonResult FetchLatestStats()
    {
         var dbStats = // get latest stats
         var myStatsModel = new MyStatsModel() { StatA = dbStats.A }; // etc
         return new Json(MyStatsModel);
    }
     $(document).ready(function () {
         var interval = 5 * 60 * 1000;  // 5 minutes
         var getLatestStats = function() {
             $.ajax({
                 type: 'GET',
                 url: '/Stats/FetchLatestStats'
                 dataType: "application/json; charset=utf-8",
                 success: function(myStatsModel) {
                     $('#someElementA').text(myStatsModel.StatA);
                     $('#someElementB').text(myStatsModel.StatB);
                     // etc
                 },
                 error: function() {
                     alert('There was an error fetching latest stats!');
                 }
             });
         };        
         setInterval(getLatestStats(), interval);
     };
