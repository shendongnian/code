        [Route("api/values")]
        public string Get(string a = "", string b = "", string c = "")
        {
            return string.Format("a={0}, b={1}, c={2}", a, b, c);
        }
=>
    /api/values?a=abc&c=xyz
