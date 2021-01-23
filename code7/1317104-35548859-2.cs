    static void Main(string[] args)
    {
        foreach (var prop in new ShellPropertyCollection(@"mypath\myfile"))
        {
            Console.WriteLine(prop.CanonicalName + "=" + prop.ValueAsObject);
        }
    }
