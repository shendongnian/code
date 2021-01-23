	public class ModelAddedEventArgs<TModel> : EventArgs
	{
		public ModelAddedEventArgs(TModel newModel)
		{
			NewModel = newModel;
		}
		public TModel NewModel { get; set; }
	}
