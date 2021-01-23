    // some sort of helper class
    public class HelperObject
    {
        public static IQueryable<MyType> GetGroupedValues(int filterID, string groupByFieldName)
        {
            // all your code/logic here
        }
    }
    // your odata controller uses the helper
    [HttpGet]
    [Route("myTypes/{filterID:int}/groupby/{groupByFieldName}")]
    public IHttpActionResult GroupMyTypes(int filterID, string groupByFieldName)
    {
        return Ok(HelperObject.GetGroupedValues(filterID, groupByFieldName));
    }
    // ... and so does your other code that wants to do the same thing
    var x = HelperObject.GetGroupedValues(filterID, groupByFieldName);
