    using System;
    using System.Reflection;
    
    class Program
    {
        // Load GemBox.Document assembly.
        static Assembly gemboxAssembly = Assembly.LoadFrom(@"C:\GemBox.Document.dll");
    
        // Create method for handling FreeLimitReached event.
        static void HandleFreeLimit(object sender, EventArgs e)
        {
            // Call: e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial
            dynamic freeLimitArgs = e;
            freeLimitArgs.FreeLimitReachedAction =
                (dynamic)Enum.Parse(
                    gemboxAssembly.GetType("GemBox.Document.FreeLimitReachedAction"),
                    "ContinueAsTrial");
        }
    
        static void Main(string[] args)
        {
            // Call: ComponentInfo.SetLicense("FREE-LIMITED-KEY")
            Type componentInfo = gemboxAssembly.GetType("GemBox.Document.ComponentInfo");
            componentInfo.GetMethod("SetLicense", BindingFlags.Public | BindingFlags.Static)
                .Invoke(null, new object[] {"FREE-LIMITED-KEY"});
    
            // Get HandleFreeLimit as MethodInfo.
            MethodInfo handleFreeLimitMethod =
                typeof(Program).GetMethod("HandleFreeLimit",
                    BindingFlags.NonPublic | BindingFlags.Static);
    
            // Call: ComponentInfo.FreeLimitReached += HandleFreeLimit
            EventInfo freeLimitReached = componentInfo.GetEvent("FreeLimitReached");
            freeLimitReached.AddEventHandler(null,
                Delegate.CreateDelegate(freeLimitReached.EventHandlerType,
                    handleFreeLimitMethod));
            
            // Call: DocumentModel document = DocumentModel.Load(@"C:\Sample.docx")
            Type documentModel = gemboxAssembly.GetType("GemBox.Document.DocumentModel");
            dynamic document = documentModel.GetMethod("Load", new Type[]{ typeof(string)})
                .Invoke(null, new object[] { @"C:\Sample.docx" });
    
            // TODO: Use "document" object as needed ...
            document.Save(@"C:\Sample.pdf");
        }
    }
