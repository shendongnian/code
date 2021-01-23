    class Program
    {
        static void Main(string[] args)
        {
            IApplicationAssociationRegistrationUI app = (IApplicationAssociationRegistrationUI)new ApplicationAssociationRegistrationUI();
            int hr = app.LaunchAdvancedAssociationUI("MyApp");
            Exception error = Marshal.GetExceptionForHR(hr);
            if (error != null)
            {
                Console.WriteLine("Error: " + error.Message);
            }
        }
    }
    [Guid("1f76a169-f994-40ac-8fc8-0959e8874710")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IApplicationAssociationRegistrationUI
    {
        [PreserveSig]
        int LaunchAdvancedAssociationUI([MarshalAs(UnmanagedType.LPWStr)] string pszAppRegName);
    }
    [ComImport]
    [Guid("1968106d-f3b5-44cf-890e-116fcb9ecef1")]
    public class ApplicationAssociationRegistrationUI
    {
    }
