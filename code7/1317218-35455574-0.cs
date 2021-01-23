     HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = fullContent ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
            response.Content = new StreamContent(responseStream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
