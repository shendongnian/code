      var jiraConnection = Jira.CreateRestClient(BASE_URL, username, password)
      var restRequest = new RestRequest("rest/api/2/issue/" + issue.JiraIdentifier);
      restRequest.Method = Method.PUT;
      restRequest.RequestFormat = DataFormat.Json;
      var requestBody = new { update = new { timetracking = new[]{ new { edit = new { originalEstimate = work.ToString()+"h" } } } } };
      restRequest.AddJsonBody(requestBody);
      IRestResponse response = jiraConnection.RestClient.ExecuteRequest(restRequest);
      if (response.ResponseStatus != ResponseStatus.Completed)
      {
        throw new System.Net.WebException("Error creating planning issue");
      }
