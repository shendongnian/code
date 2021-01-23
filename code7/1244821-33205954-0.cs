    public class Item {
        public string Value {get;set;}
        public Item(string value){
            Value = value;
        }
        public bool IsChanged { get; private set;}
        public void SetChanged(){
           IsChanged = true;
        }
        public override string ToString(){
           return Value;
        }
        public override bool Equals(object other){
            var item = other as Item;
            if(item == null) return false;
            return item.Value == Value;
        }
        public override int GetHashCode(){
            if(Value == null) return base.GetHashCode();
            return Value.GetHashCode();
        }
    }
