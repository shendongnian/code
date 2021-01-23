    namespace DialogServiceInterfaceLibrary
    {
        public enum MessageBoxButton  
        {
        // Summary:
        //     The message box displays an OK button.
        OK = 0,
        //
        // Summary:
        //     The message box displays OK and Cancel buttons.
        OKCancel = 1,
        //
        // Summary:
        //     The message box displays Yes, No, and Cancel buttons.
        YesNoCancel = 3,
        //
        // Summary:
        //     The message box displays Yes and No buttons.
        YesNo = 4,
        }
        public enum MessageBoxResult
        {
        // Summary:
        //     The message box returns no result.
        None = 0,
        //
        // Summary:
        //     The result value of the message box is OK.
        OK = 1,
        //
        // Summary:
        //     The result value of the message box is Cancel.
        Cancel = 2,
        //
        // Summary:
        //     The result value of the message box is Yes.
        Yes = 6,
        //
        // Summary:
        //     The result value of the message box is No.
        No = 7,
        }
        // Summary:
        //     Specifies the icon that is displayed by a message box.
        public enum MessageBoxIcon
        {
        // Summary:
        //     No icon is displayed.
        None = 0,
        //
        // Summary:
        //     The message box contains a symbol consisting of white X in a circle with
        //     a red background.
        Error = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of a white X in a circle with
        //     a red background.
        Hand = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of white X in a circle with
        //     a red background.
        Stop = 16,
        //
        // Summary:
        //     The message box contains a symbol consisting of a question mark in a circle.
        Question = 32,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Exclamation = 48,
        //
        // Summary:
        //     The message box contains a symbol consisting of an exclamation point in a
        //     triangle with a yellow background.
        Warning = 48,
        //
        // Summary:
        //     The message box contains a symbol consisting of a lowercase letter i in a
        //     circle.
        Information = 64,
        //
        // Summary:
        //     The message box contains a symbol consisting of a lowercase letter i in a
        //     circle.
        Asterisk = 64,
        }
        public interface IDialogService
        {
            bool OpenFileDialog(bool checkFileExists,string Filter, out string FileName);
            void OpenGenericDialog(object Context,IRegionManager RegionManager);
        MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton buttons, MessageBoxIcon icon);
        }
