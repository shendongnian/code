    Uri tfsUri = new Uri(projectCollection.Uri.ToString());
        VersionControlServer controlServer = projectCollection.GetService<VersionControlServer>();
        var hHistory = controlServer.QueryHistory("$/MyPath/",
                                                    VersionSpec.Latest,
                                                    0,
                                                    RecursionType.Full,
                                                    String.Empty,
                                                    VersionSpec.ParseSingleSpec(changeset.ChangesetId.ToString(), null),
                                                    VersionSpec.ParseSingleSpec(changeset.ChangesetId.ToString(), null),
                                                    int.MaxValue,
                                                    false,
                                                    false,
                                                    true);
