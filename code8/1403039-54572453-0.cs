    var release = GetReleaseForProject(project, "rc1");
    public ReleaseResource GetReleaseForProject(ProjectResource project, string versionPattern = "")
    {
    	// create compiled regex expression to use for search
    	var regex = new Regex(versionPattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    	var releases = Repo.Projects.GetReleases(project);
    	if (!string.IsNullOrWhiteSpace(versionPattern) && !releases.Items.Any(r => regex.IsMatch(r.Version)))
    	{
    		return null;
    	}
    	return (!string.IsNullOrWhiteSpace(versionPattern)) ? releases.Items.Where(r => regex.IsMatch(r.Version))?.First() : releases.Items?.First();;
    }
