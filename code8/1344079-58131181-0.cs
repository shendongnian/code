        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] params string[] parameters)
        {
            string queryString;
            if (parameters.Length != 0)
            {
                queryString = "?" + string.Join('&', parameters);
            }
            else
            {
                queryString = string.Empty;
            }
            return Ok(await DoMagic.GetAuthorizationTokenAsync(new Uri($"https://someurl.com/token-endpoint{queryString}")));
        }
