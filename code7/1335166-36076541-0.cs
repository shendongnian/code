    var github = new GitHubClient(...); // TODO: other setup
    var contents = await github
                    .Repository
                    .Content
                    .GetAllContents("octokit", "octokit.net");
    ...
    var docs = await github
                    .Repository
                    .Content
                    .GetAllContents("octokit", "octokit.net", "docs");
