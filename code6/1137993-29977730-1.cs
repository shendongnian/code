    public class TitleEstimateController : ApiController
    {
        public IHttpActionResult GetTitleEstimate([FromUri] EstimateQuery query)
        {
            // All the values in "query" are null or zero
            // Do some stuff with query if there were anything to do
         }
    }
    public class EstimateQuery
    {
        public string QueryName{ get; set; }
        public string Whatever{ get; set; }
    }
    $(function () {
       var query = {QueryName:"My Query",Whatever:"Blah"};
       $.ajax({
           type: "GET",
           data :JSON.stringify(query),
           url: "api/titleEstimate",
           contentType: "application/json"
       })
          .done(function (data) {
              $('#product').text("OK");
          })
          .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
          });
    });
