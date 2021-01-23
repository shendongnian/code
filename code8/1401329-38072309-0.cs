     var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(@"$/MyFolder1/MyFolder2/MyFolder3");
                    if (workspaceInfo != null) //is already exists
                    {
                        var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri);
                        workspace = workspaceInfo.GetWorkspace(server);
                    }
