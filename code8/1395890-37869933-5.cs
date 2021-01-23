    ShellObject picture = ShellObject.FromParsingName(file);
    
    var camera = picture.Properties.GetProperty(SystemProperties.System.Photo.CameraModel);
    newItem.CameraModel = GetValue(camera, String.Empty, String.Empty);
    
    var company = picture.Properties.GetProperty(SystemProperties.System.Photo.CameraManufacturer);
    newItem.CameraMaker = GetValue(company, String.Empty, String.Empty);
