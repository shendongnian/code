	 /// <summary>
	 /// Finds a web.config/app.config file in the passed project and returns the file name.
	 /// If none are found, returns null.
	 /// </summary>
	 private string FindConfigurationFilename(EnvDTE.Project project)
	 {
	  // examine each project item's filename looking for app.config or web.config
	  foreach (EnvDTE.ProjectItem item in project.ProjectItems)
	  {
	   if (Regex.IsMatch(item.Name,"(app|web).config",RegexOptions.IgnoreCase))
	   {
		// TODO: try this with linked files. is the filename pointing to the source?
		return item.get_FileNames(0);
	   }
	  }
>	 
	  // not found, return null
	  return null;
	 }
