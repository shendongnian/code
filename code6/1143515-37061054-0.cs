    private static void EnumerateContentsInTargetDirectory(ref IPortableDeviceContent content, PortableDeviceFolder parent)
    {
        // Get the properties of the object
        IPortableDeviceProperties properties;
        content.Properties(out properties);
        // Enumerate the items contained by the current object
        IEnumPortableDeviceObjectIDs objectIds;
        content.EnumObjects(0, parent.Id, null, out objectIds);
        uint fetched = 0;
        do
        {
            string objectId;
            objectIds.Next(1, out objectId, ref fetched);
            if (fetched > 0)
            {
                var currentObject = WrapObject(properties, objectId);
                if (currentObject is PortableDeviceFolder)
                {
                    if (currentObject.Name.Equals("SD Card") || currentObject.Name.Equals("path") || currentObject.Name.Equals("to"))
                    {
                        parent.Files.Add(currentObject);
                        EnumerateContentsInTargetDirectory(ref content, (PortableDeviceFolder)currentObject);
                    }
                    else if (currentObject.Name.Equals("directory"))
                    {
                        parent.Files.Add(currentObject);
                        // This is the same original method of Christophe Geer.
                        EnumerateContents(ref content, (PortableDeviceFolder)currentObject);
                    }
                }
            }
        } while (fetched > 0);
}
