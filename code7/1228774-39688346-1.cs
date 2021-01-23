       using (var serverManager = new ServerManager())
                {
                    string siteName = RoleEnvironment.CurrentRoleInstance.Id + "_" + "Web";
                    var siteId = serverManager.Sites[siteName].Id;
                    var appVirtualDir = $"/LM/W3SVC/{siteId}/ROOT";  // Do not end this with a trailing /
                    var clientBuildManager = new ClientBuildManager(appVirtualDir, null, null,
                                                new ClientBuildManagerParameter
                                                {
                                                    PrecompilationFlags = PrecompilationFlags.Default,
                                                });
                    clientBuildManager.PrecompileApplication();
                }
