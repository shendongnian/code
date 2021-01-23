    private async void buttonOk_Click(object sender, System.EventArgs e)
    {
        var asyncResolvedIssue = api.ResolveIssue(issue, revision, pathList);
        if (await asyncResolvedIssue) {} // <== no deadlock!
    }
