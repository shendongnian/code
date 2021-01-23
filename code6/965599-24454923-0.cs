    public class YourCollection : Collection<KeyValuePair<int, double>>
    {
       protected override void InsertItem(int index, KeyValuePair<int, double> item)
       {
          if (this.Any() && item.Value <= this.Min(e => e.Value))
             base.InsertItem(index, item);
       }
    }
