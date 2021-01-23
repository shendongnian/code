    public int? CheckInPendingChanges(PendingChange[] pendingChanges, string comments)
        {
            using (TfsTeamProjectCollection pc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConstTfsServerUri)))
            {
                if (pc == null) return null;
                WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(ConstDefaultFlowsTfsPath);
                Workspace workspace = workspaceInfo?.GetWorkspace(pc);
                try
                {
                    int? result = workspace?.CheckIn(pendingChanges, comments);
                    return result;
                }
                catch (CheckinException exception)
                {
                    UIHelper.Instance.RunOnUiThread(() => MessageBox.Show(exception.Message, "Check in exception has happened", MessageBoxButton.OK, MessageBoxImage.Error));
                    return null;
                }
                catch (VersionControlException exception)
                {
                    UIHelper.Instance.RunOnUiThread(() => MessageBox.Show(exception.Message, "Version Control Exception has happened", MessageBoxButton.OK, MessageBoxImage.Error));
                    return null;
                }
            }
        }
