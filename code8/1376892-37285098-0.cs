    var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserAccessToken);
    var requestUri = $"https://graph.windows.net/me/changePassword?api-version={Constants.ApiVersion}";
    var pwdObject = new { currentPassword = curPassword, newPassword = newPass };
    var body = new JavaScriptSerializer().Serialize(pwdObject);
    var response = client.PostAsync(new Uri(requestUri), new StringContent(body, Encoding.UTF8, "application/json")).Result;
