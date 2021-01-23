    [Route("api/[controller]")] /* this is the defualt prefix for all routes, see line 20 for overridding it */
    public class ValuesController : Controller
    {
        [HttpGet] // this api/Values
        public string Get()
        {
            return string.Format("Get: simple get");
        }
 
        [Route("GetByAdminId")] /* this route becomes api/[controller]/GetByAdminId */
        public string GetByAdminId([FromQuery] int adminId)
        {
            return $"GetByAdminId: You passed in {adminId}";
        }
 
        [Route("/someotherapi/[controller]/GetByMemberId")] /* note the / at the start, you need this to override the route at the controller level */
        public string GetByMemberId([FromQuery] int memberId)
        {
            return $"GetByMemberId: You passed in {memberId}";
        }
 
        [HttpGet]
        [Route("IsFirstNumberBigger")] /* this route becomes api/[controller]/IsFirstNumberBigger */
        public string IsFirstNumberBigger([FromQuery] int firstNum, int secondNum)
        {
            if (firstNum > secondNum)
            {
                return $"{firstNum} is bigger than {secondNum}";
            }
            return $"{firstNum} is NOT bigger than {secondNum}";
        }
    }
