    public class POCOSerializer
    {
        public static void Serialize(string dllFileName, GenerateBulkVmXML batchSerializer)
        {
            var assem = Assembly.LoadFrom(dllFileName);
            var pocoObjects = assem.GetTypes().Where(t => t.GetCustomAttribute<SerializePOCOAttribute>() != null);
            foreach (var poco in pocoObjects)
            {
                batchSerializer.AddPocoModel(poco, poco.Namespace);
            }
            batchSerializer.WriteXML();
        }
    }
