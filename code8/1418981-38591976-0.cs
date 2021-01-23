<!-- -->
	public class CallCommand : MarkupExtension, ICommand
	{
		public string MethodName { get; set; }
		FrameworkElement element;
		public CallCommand() { }
		public CallCommand(string methodName) : this()
		{
			MethodName = methodName;
		}
		public event EventHandler CanExecuteChanged;
		public bool CanExecute(object parameter)
		{
			return true;
		}
		public void Execute(object parameter)
		{
			if (MethodName == null) throw new InvalidOperationException($"{nameof(MethodName)} cannot be null.");
			var context = element.GetValue(FrameworkElement.DataContextProperty);
			context.GetType().GetMethod(MethodName).Invoke(context, null);
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
			element = (FrameworkElement)target.TargetObject;
			return this;
		}
	}
