    [HttpPost]
    [Route("api/BarChart/GetBarChart")]
    public HttpResponseMessage GetBarChart(BarChart barChart)
    {
        try
        {
           Debug.WriteLine(barChart);
           // do something useful with the barChart...
           return Request.CreateResponse(HttpStatusCode.OK, "true");
        }
        catch (Exception ex)
        {
           return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        }
    }
