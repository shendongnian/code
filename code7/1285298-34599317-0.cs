    public class ZebrasController : ODataController
    {
        [HttpGet]
        [ODataRoute("Zebras/Default.WhereGrowthEquals(value={value})")]
        public IHttpActionResult WhereGrowthEquals(decimal value)
        {
            return this.Ok(AllZebras.Where(z => z.Proposals[0].Growth.Value == value));
        }
    }
