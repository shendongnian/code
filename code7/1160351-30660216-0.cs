    var replacements = dir.GetFiles()
                          .Where(file => animals.Any(animal => file.Name.StartsWith(animal))
                          .Select(file => new 
                                         {
                                           OldFullName = file.FullName, 
                                           NewFullName = file.FullName.Replace(file.Name, "Animals-" + file.Name) 
                                         })
                          .ToList();
    
    foreach (var replacement in replacements)
    {
    	File.Move(replacement.OldFullName, replacement.NewFullName);
    }
