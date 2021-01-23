    namespace SampleWpfUserControlLibrary
    {
        public interface IApplicationHostWindow
        {
            void OpenDocument();
            unsafe void* GetPresentationPtr();
            void Exit();
        }
    }
