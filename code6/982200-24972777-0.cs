    var extension = Path.GetExtension(filePathNameAndExtension).ToLower();
    select(extension)
    {
        case ".jpg":
        case ".png":
        case ".jpeg":
            type = Type.Image;
            break;
        case ".txt":
            type = Type.Text;
            break;
        default:
            type = Type.Unknown;
            break;
    }
    select(type)
    {
        case Type.Unknown:
            System.Diagnostics.Process.Start(filePathNameAndExtension);
            break;
        case Type.Image:
            myImage = new Bitmap(filePathNameAndExtension);
            break;
        .....
    }
    
    
