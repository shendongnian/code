            using (var client = new HttpClient())
            {
                var response =
                    await client.GetAsync("http://localhost:51137/api/Account/Register");
                if (!response.IsSuccessStatusCode)
                {
                    // Unwrap the response and throw as an Api Exception:
                    var ex = CreateExceptionFromResponseErrors(response);
                    throw ex;
                }
            }
