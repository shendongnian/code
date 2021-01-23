    var userDescription = (string)userDirectoryData.Properties["description"].Value ?? String.Empty;
    if (userDescription.IndexOf("Contracted") > -1)
    {
        continue;
    }
    else
    {
        //Do Stuff here
    }
