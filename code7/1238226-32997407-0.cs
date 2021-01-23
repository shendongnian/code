    using System.Runtime.InteropServices;
    
    namespace LibraryName {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IFoo {
            void DoMethod(string name, object args);
        }
    }
