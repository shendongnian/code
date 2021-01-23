        [HttpGet("{*longUrl}")]
        public string ShortUrl(string longUrl)
        {
            var test = longUrl + Request.QueryString;
            return JsonConvert.SerializeObject(GetUrlToken(test));
        }
