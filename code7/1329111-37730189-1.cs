        private void AddHeaders()
        {
            //foreach (var header in content.Headers)
            //{
            //    Headers.TryAddWithoutValidation(header.Key, header.Value);
            //}
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Headers.ContentEncoding.Add(compressor.EncodingType);
        }
