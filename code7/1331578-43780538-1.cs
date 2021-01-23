    var request = new HttpRequestMessage {
        RequestUri = new Uri(EnvironmentSetup.BaseAddress + "Folder"),
        Method = HttpMethod.Post,
        Headers = {
            { HttpRequestHeader.Authorization.ToString(), "Basic " + EnvironmentSetup.GetAuthToken() },
            { HttpRequestHeader.ContentType.ToString(), "multipart/mixed" },
        },
        Content = new MultipartContent {
            new ObjectContent<FolderWithDocuments>(new FolderWithDocuments {
                Status = FolderStatus.Draft,
                Users = new List<User> { EnvironmentSetup.User1, EnvironmentSetup.User2 },
            }, new JsonMediaTypeFormatter(), "application/json"),
            new ByteArrayContent(ResourceHelper.ReadResourceToByteArray("blank.pdf")) {
                Headers = {
                    { "Content-Type", "application/Executable" },
                    { "Content-Disposition", "form-data; filename=\"test.pdf\"" },
                },
            },
        },
    };
