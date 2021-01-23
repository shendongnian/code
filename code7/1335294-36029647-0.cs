        public async void Post([FromBody]TestModel value)
        {
            var stream = await this.Request.Content.ReadAsStreamAsync();
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            Console.Write(text);
        }
