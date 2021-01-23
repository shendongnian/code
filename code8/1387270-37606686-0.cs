    return new HttpResponseMessage
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(v),
                        System.Text.Encoding.UTF8,
                        "application/json")
                };
