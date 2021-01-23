  public static async Task<HttpResponseMessage> HttpClientPost(string header, string postdata, string url)
        {
            string uri = apiUrl + url;
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", header);
                HttpResponseMessage response = await client.PostAsync(uri, new StringContent(postdata));
                return response;
            }
        }
This is my controller code, where I call the function and read the response and determine whether I have an error or not and respond accordingly. Note that I am checking the IsSuccessStatusCode.
                HttpResponseMessage response;
                string url = $"Setup/AddDonor";
                var postdata = JsonConvert.SerializeObject(donor);
                response = await ApiHandler.HttpClientPost(HttpContext.Session.GetString(tokenName), postdata, url);
                //var headers = response.Headers.Concat(response.Content.Headers);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    tnxresult = JsonConvert.DeserializeObject<TnxResult>(AppFunctions.CleanResponse(responseBody));
                    return Json(new
                    {
                        ok = true,
                        message = tnxresult.Message,
                        statusCode = tnxresult.StatusCode
                    });
                }
                else
                {
                  ApiError rs = JsonConvert.DeserializeObject<ApiError>(AppFunctions.CleanResponse(responseBody));
                    return Json(new
                    {
                        ok = false,
                        message = rs.Message,
                        statusCode = rs.StatusCode
                    });
                }
My API returns error messages in JSON. If the call is successful, I am packing the response in JSON too.
The crucial line of code is this one...
var responseBody = await response.Content.ReadAsStringAsync();
It serializes the HTTP content to a string as an asynchronous operation.
After that I can convert my JSON string to an object and access the error/success message and the Status Code too.
