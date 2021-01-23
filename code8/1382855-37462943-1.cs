    public class HomeController1 : Controller
    {
        [Route("sample1/{oSampleId:regex(^[cd]{1}\\d+$)}")]
        public ActionResult Sample1(BusinessObjectId oSampleId)
        {
            // TODO: oSampleId is successfully parsed from it's string representations
        }
    }
