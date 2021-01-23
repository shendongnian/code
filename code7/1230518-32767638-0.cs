        [HttpGet("getList")]
        public async Task<string> Get(string token, string page, string amount) {
            var t = await Task.Run(() => {
                return CustomerDA.getList(token, page, amount);
            });
            return t;
        }
