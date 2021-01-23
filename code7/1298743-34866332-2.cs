    public class HideImplementationEnumerable<T>
    {
	public HideImplementationEnumerable(IEnumerable<T> Source)
	{
		this.Source = Source;
	}
	
	private IEnumerable<T> Source;
	public IEnumerable<T> Value
	{
		get
		{
			foreach (var item in Source)
			{
				yield return item;
			}
		}
	}
    }
