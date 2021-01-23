    [ExportMetadata("guid", "0db79a169xy741229a1b558a07867d60")]
    class PluginExport
    {
        void PrintGuid()
        {
            var guid = this.GetType()
                           .GetCustomAttributes(false)
                           .OfType<ExportMetadataAttribute>()
                           .Single(attribute => attribute.Name == "guid").Value;
            Console.WriteLine(guid); // Prints your value.
        }
    }
