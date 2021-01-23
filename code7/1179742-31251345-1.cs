         public async Task<HttpResponseMessage> GetJsonDouble()
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"records\":[ {\"Name\":\"Alfreds Futterkiste\",\"City\":\"Berlin\",\"Country\":\"Germany\"}, {\"Name\":\"Ana Trujillo Emparedados y helados\",\"City\":\"México D.F.\",\"Country\":\"Mexico\"}]}")
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return result;
        }
