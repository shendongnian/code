        private HttpResponseMessage Respond(string text)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(text),
            };
            return response;
        }
