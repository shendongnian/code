		public class Item : IDisposable
		{
			public int id { get; set; }
		
			private Action action;
			public event SendMessage MessageEvent;
		
			public Item()
			{
				action = () => Console.WriteLine("Bad thing happens");
				MessageEvent += action;
				UpdateAsync();
			}
			
			public void Dispose()
			{
				Dispose(true);
			}
			
			protected virtual void Dispose(bool disposing)
			{
				if (!disposing)
					return;
				
				MessageEvent -= action;
			}
		}
		
		public class Data
		{
			public ObservableCollection<Item> Items { get; set; }
			public Data()
			{
				Items = new ObservableCollection<Item>();
				Items.Add(new Item { id = 1});
			}
		
			public void CleanCollection()
			{
				foreach (var item in Items)
				{
					item.Dispose();
				}
				
				items.Clear();
			}
		}
