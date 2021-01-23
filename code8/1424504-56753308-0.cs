csharp
var myJsonFile = ReadManifestData<Tests>("myJsonFile.json");
Method:
public static string ReadManifestData<TSource>(string embeddedFileName) where T: class
{
    var assembly = typeof(TSource).GetTypeInfo().Assembly;
    var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith(embeddedFileName,StringComparison.CurrentCultureIgnoreCase));
    
    using (var stream = assembly.GetManifestResourceStream(resourceName))
    {
        if (stream == null)
        {
            throw new InvalidOperationException("Could not load manifest resource stream.");
        }
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}
