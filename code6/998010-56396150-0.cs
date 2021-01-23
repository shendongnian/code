csharp
using System.Data.Entity.SqlServer;
public class ContainerConfiguration
{
    // HACK: This code snippet ensures that the DLL (EntityFramework.SqlServer.dll)
    // not removed by compiler optimizer (csc.exe roslyn)
    public static SqlProviderServices EntitySqlServerHack => SqlProviderServices.Instance;
    public void ContainerConfiguration(IContainer container)
    {
        InternalConfigure(container, false);
    }
}
