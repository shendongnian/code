     jira = new Jira.CreateRestClient("https://jira.com", LoginUI.username, LoginUI.password, null);
     var issue = jira.CreateIssue(projectKey);
     
     issue.Type = "Epic";
     issue.Summary = "Test Summary";
     string epicname = "test";
     issue.CustomFields.Add("Epic Name", epicname);
    
     issue.SaveChanges();
