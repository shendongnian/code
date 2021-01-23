     /// <summary>
    /// Specifices that the target class is a view model. This is a marker interface and has no methods.
    /// </summary>
    public interface IViewModel
    {
    	// Marker interface
    }
    
    /// <summary>
    /// Handles the <typeparamref name="TViewModel"/>.
    /// </summary>
    /// <typeparam name="TViewModel">The view model which should be handled.</typeparam>
    public interface IHandleViewModel<out TViewModel> where TViewModel : IViewModel
    {
    	/// <summary>
    	/// Creates a <typeparamref name="TViewModel"/>.
    	/// </summary>
    	/// <returns>An instance of the <typeparamref name="TViewModel"/>.</returns>
    	TViewModel Handle();
    }
    
    /// <summary>
    /// Handles the <typeparamref name="TViewModel"/> with the argument of <typeparamref name="TInput"/>
    /// </summary>
    /// <typeparam name="TInput">The argument for the view model</typeparam>
    /// <typeparam name="TViewModel">The view model which should be handled.</typeparam>
    public interface IHandleViewModel<out TViewModel, in TInput> where TViewModel : IViewModel
    {
    	/// <summary>
    	/// Creates a <typeparamref name="TViewModel"/>.
    	/// </summary>
    	/// <returns>An instance of the <typeparamref name="TViewModel"/>.</returns>
    	TViewModel Handle(TInput input);
    }
    
    /// <summary>
    /// Processes and creates view models.
    /// </summary>
    public interface IProcessViewModels
    {
    	/// <summary>
    	/// Creates the <typeparamref name="TViewModel"/>.
    	/// </summary>
    	/// <returns>The view model</returns>
    	TViewModel Create<TViewModel>() where TViewModel : IViewModel;
    
    	/// <summary>
    	/// Create the <typeparamref name="TViewModel"/> with an argument of type <typeparamref name="TInput"/> 
    	/// </summary>
    	/// <typeparam name="TViewModel">The view model which should be constructed</typeparam>
    	/// <typeparam name="TInput">The type of argument for the view model</typeparam>
    	/// <param name="input">The argument for the view model</param>
    	/// <returns>The view model</returns>
    	TViewModel Create<TViewModel, TInput>(TInput input) where TViewModel : IViewModel;
    }
