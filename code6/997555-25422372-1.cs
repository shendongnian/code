	public class ListViewWithVisible : ListView
	{
		private List<Item1> list = new List<Item1>();
		public class Item1 : ListViewItem
		{
			public bool Visible = true;
			public ListViewItem Value = null;
			public override string ToString()
			{
				return (Value == null ? String.Empty : Value.ToString());
			}
		}
		public Item1 this[int i] {
			get {
				return list[i];
			}
		}
		public int Count {
			get {
				return list.Count;
			}
		}
		public List<Item1> Lista {
			get {
				return list;
			}
		}
		public void Add(ListViewItem o)
		{
			Item1 item = new Item1 { Value = o, Text = (o == null ? string.Empty : o.Text), BackColor = o.BackColor };
			Items.Add(o);
			list.Add(item);
		}
		public void RefreshVisibleItems()
		{
			ListViewItem top = this.TopItem;
			Items.Clear();
			int k = 0;
			foreach (Item1 o in list)
			{
				if (o == top)
					break;
				if (o.Visible)
					k++;
			}
			Items.AddRange(list.FindAll(i => i.Visible).ToArray());
			if (k < Items.Count)
				this.TopItem = Items[k];
		}
	}
