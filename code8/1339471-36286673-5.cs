        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var dataObj = new
            {
                errors = errors.ToArray(),
                message = Message ?? string.Join(", ", errors)
            };
            
            if (_request.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue("applicaiton/xml")))
            {
                Console.WriteLine("Foo");
            }
            ///// Changed Line
            var resp = _request.CreateErrorResponse(HttpStatusCode.BadRequest, yourDictionaryCollection);
            return Task.FromResult(resp);
        }
    
