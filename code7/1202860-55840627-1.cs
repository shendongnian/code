        [HttpPost]
        public async Task<ActionResult<int>> Process()
        {
            string jsonString;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                jsonString = await reader.ReadToEndAsync();
            }
