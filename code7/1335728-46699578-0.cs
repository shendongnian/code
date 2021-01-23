    using System;
    using System.Linq;
    using System.Windows.Input;
    using Windows.ApplicationModel;
    using Windows.Foundation.Metadata;
    using Windows.UI.Core;
    using Windows.UI.StartScreen;
    using Windows.UI.Xaml;
    namespace Synergist
    {
        /// <summary>
        ///     Pin the first entry in the package's app list to the start screen
        /// </summary>
        public class PinToStartCommand : ICommand
        {
            private bool _canExecute;
            /// <summary>
            ///     Initializes a new instance of the PinToStartCommand class.
            /// </summary>
            public PinToStartCommand()
            {
                Window.Current.Activated += Current_Activated;
            }
            /// <summary>
            ///     Can execute changed event handler
            /// </summary>
            public event EventHandler CanExecuteChanged;
            /// <summary>
            ///     returns true if the StartScreenManager exists
            /// </summary>
            /// <param name="parameter">the parameter is not used</param>
            /// <returns>true if the app is not pinned to the start screen and the API is available</returns>
            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }
            /// <summary>
            ///     Pin the app to the start screen
            /// </summary>
            /// <param name="parameter">the parameter is not used.</param>
            public async void Execute(object parameter)
            {
                if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
                {
                    var entries = await Package.Current.GetAppListEntriesAsync();
                    var firstEntry = entries.FirstOrDefault();
                    if (firstEntry == null)
                        return;
                    var startScreenmanager = StartScreenManager.GetDefault();
                    var containsEntry = await startScreenmanager.ContainsAppListEntryAsync(firstEntry);
                    if (containsEntry)
                        return;
                    if (await startScreenmanager.RequestAddAppListEntryAsync(firstEntry))
                    {
                        _canExecute = false;
                        CanExecuteChanged?.Invoke(this, new EventArgs());
                    }
                }
            }
            private async void Current_Activated(object sender, WindowActivatedEventArgs e)
            {
                var entries = await Package.Current.GetAppListEntriesAsync();
                var firstEntry = entries.FirstOrDefault();
                if (firstEntry == null)
                {
                    _canExecute = false;
                    return;
                }
                if (ApiInformation.IsTypePresent("Windows.UI.StartScreen.StartScreenManager"))
                {
                    var startScreenmanager = StartScreenManager.GetDefault();
                    _canExecute = !await startScreenmanager.ContainsAppListEntryAsync(firstEntry);
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                }
            }
        }
    }
