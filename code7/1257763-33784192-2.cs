	/// <summary>
	/// A generic command whose sole purpose is to relay its functionality to other
	/// objects by invoking delegates. The default return value for the CanExecute
	/// method is 'true'. This class allows you to accept command parameters in the
	/// Execute and CanExecute callback methods.
	/// 
	/// </summary>
	/// <typeparam name="T">The type of the command parameter.</typeparam>
	/// <remarks>
	/// If you are using this class in WPF4.5 or above, you need to use the
	/// GalaSoft.MvvmLight.CommandWpf namespace (instead of GalaSoft.MvvmLight.Command).
	/// This will enable (or restore) the CommandManager class which handles
	/// automatic enabling/disabling of controls based on the CanExecute delegate.
	/// </remarks>
