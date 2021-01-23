    public class Foo 
    {
        public int A {get;set;}
        public string B {get;set;}
        public object GetPropertyValueAt(int index)
        {
            var prop = this.GetType().GetProperties()[index];
            return prop.GetValue(this, null);
        }
    }
