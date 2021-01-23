    [TestMethod]
    public void Can_Store_A_Userrole_Via_REST_WebAPI()
    {
        var request = new RestRequest(ApiBasePath, Method.POST);
    
        request.AddUrlSegment("segment", "UserRoles");
        request.AddUrlSegment("segment", AppCode);
        request.RequestFormat = DataFormat.Json;
        request.AddBody(
            new UserroleDto()
            {
                UserRoleId = -1,
                Role = "Developer"
            });
    
        _restClient.Execute(request);
    }
