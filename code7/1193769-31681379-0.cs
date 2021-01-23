    HttpClient http = new System.Net.Http.HttpClient();
                HttpResponseMessage response = await http.GetAsync(JsonBaseuri + IDInput.Text.ToString());
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                MessageDialog x = new MessageDialog(content, "JsonData");
