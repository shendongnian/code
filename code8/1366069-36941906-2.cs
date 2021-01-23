    var auth = 
        new JObject(
            new JProperty("auth", 
                new JObject(
                    new JProperty("identity", 
                        new JObject(
                            new JProperty("methods", new JArray("password")),
                            new JProperty("password", 
                                new JObject(
                                    new JProperty("user", 
                                        new JObject(
                                            new JProperty("id", identityWithProject.Username),
                                            new JProperty("password", identityWithProject.ProjectName)
                                        )
                                    )
                                )
                            )
                        )
                    ),
                    new JProperty("scope", 
                        new JObject(
                            new JProperty("project", 
                                new JObject(
                                    new JProperty("id", identityWithProject.ProjectName)
                                )
                            )
                        )
                    )
                )
            )
        );
