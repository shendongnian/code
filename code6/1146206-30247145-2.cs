    public static class Commands
    {
        private static RelayCommand _savePartsCommand;
        public static ICommand SavePartCommand
        {
            get
            {
                return _savePartsCommand ?? 
                    (_savePartsCommand = new RelayCommand(() => 
                        Console.WriteLine(@"Save"), CanExecuteSavePartsCommand));
            }
        }
        public static bool ToggleCanExecuteSavePartsCommand { get; set; }
        private static bool CanExecuteSavePartsCommand()
        {
            return ToggleCanExecuteSavePartsCommand;
        }
    }
