    var settings = Regex.Split(settings_received_from_server, @"(?=\[\w+\])")
    	.ToDictionary(
    		section => Regex.Match(section, @"\[(?<section>\w+)\]").Groups["section"].Value,
    		section => section.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
    			// remove empty line or section header
    			.Where(line => !string.IsNullOrWhiteSpace(line) && !Regex.IsMatch(line, @"\[.+\]"))
    			// see note below
    			.Select(line => Regex.Match(line, @"(?<key>\w+)\s*=\s*(?<value>.+)"))
    			.ToDictionary(
    				match => match.Groups["key"].Value,
    				match => match.Groups["value"].Value));
	
    // to get the setting use the following : [section][key]
	settings["AvatarService"]["AvatarServerURI"]
