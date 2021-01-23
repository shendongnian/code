    public interface IMyItem
    {
        string Type;
    }
    public class Item1 : IMyItem
    {
        public string Type{get{return "Item1";}}
    }
    public class Item2: IMyItem
    {
        public string Type{get{return "Item2";}}
    }
    public void CalcItems(IMyItem item, int val){
        this.Log(item.Type + "Val:" + val);
        this.total += val;
    }
    Items.CalcItems(new Item1(), 30);
    Items.CalcItems(new Item2(), 12);
