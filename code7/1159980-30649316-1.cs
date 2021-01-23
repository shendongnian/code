    [Route("api/[controller]")]
    public class UrlController : Controller
    {
        [HttpGet("{*longUrl}")]
        public string ShortUrl(string longUrl)
        {
            var test = longUrl + Request.QueryString;
            return JsonConvert.SerializeObject(GetUrlToken(test));
        }
