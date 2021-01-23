    protected override void PublishResults(Java.Lang.ICharSequence constraint, Filter.FilterResults results)
		{
			if (results.Count == 0)
				this.TdAdapter.NotifyDataSetInvalidated();
			else
			{
				System.Object obj = results.Values.ToNetObject<System.Object>();
				IEnumerable enumerable = obj as IEnumerable;
				List<TodoItem> LTdi = new List<TodoItem> ();
				if (enumerable != null)
				{
					foreach(object element in enumerable)
					{
						LTdi.Add (element as TodoItem);
					}
				}
					
				TdAdapter._originaltodoItemList = LTdi.ToArray();
				TdAdapter.NotifyDataSetChanged();
			}
		}
