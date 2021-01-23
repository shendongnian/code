    public class PhoneList<T> : Collection<T> where T : PhoneNumber
    {
		protected override void InsertItem(int index, T item)
		{
			if (this.Count() < 10)
			{
				base.InsertItem(index, item);		
			}
		}
    }
