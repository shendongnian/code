    using System.IO;
    if (result != null)
    {
    FilePath = FilePath + EntityName;
	if(CheckIfFolderExists(FilePath + EntityName)==false) //Check primary folder, if do not exists create one
	{
	    Directory.CreateDirectory(FilePath + EntityName); //Create primary folder
    }
    FilePath+= "\\"; 
    foreach (Entity e in result.Entities)
    {  
        if(CheckIfFolderExists(FilePath + e.GetAttributeValue<EntityReference>("objectid").Id.ToString()))==false) //Check subfolder, if do not exists create one
	    {
	     Directory.CreateDirectory(FilePath + e.GetAttributeValue<EntityReference>("objectid").Id.ToString()); //Create subfolder inside primary folder
        }
    //Also check here, if file with the same name already exists, if not create one
        if (!String.IsNullOrWhiteSpace(e.Attributes["documentbody"].ToString()) && !File.Exists(FilePath + e.Attributes["filename"].ToString()))
        {
            byte[] data = Convert.FromBase64String(e.Attributes["documentbody"].ToString());
            File.WriteAllBytes(FilePath + e.Attributes["filename"].ToString(), data);
        }
    }
    }
    public static bool CheckIfFolderExists(string path)
    {
     return Directory.Exists(path);
    }
