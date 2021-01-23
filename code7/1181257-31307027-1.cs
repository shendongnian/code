    public class PlotListController : ApiController
    {
        [Route("api/plotlist")]
        [HttpGet]
        public IEnumerable<CTDIDataPoint> GetPlotList()
        {....
