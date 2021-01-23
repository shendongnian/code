    var userDescription = (string)userDirectoryData.Properties["description"].Value ?? String.Empty;
    if (userDescription.Contains("Contracted"))
    {
        continue;
    }
    else
    {
        //Do Stuff here
    }
