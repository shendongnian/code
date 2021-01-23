            // POST: api/Vizzini
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetResponse(string tweet)
        {
            string s = await Task.Run(() =>
            {
                return ResponseEngine.GetBestResponse(tweet);
            });
            return Ok(s);
        }
