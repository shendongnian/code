    public class NewArrayList : ArrayList 
    {
        public event EventHandler Change; 
    
        public override int Add(object value)
        { 
           var result = base.Add(value);
            this.OnChange();
            return result;
        }
    
        public override void Remove(object obj)
        {
            base.Remove(obj);
            this.OnChange();
        }
    
        protected void OnChange()
        {
            if (this.Change != null)
            {
                this.Change(this, new EventArgs() { });
            }
        }
    }
    public static class program
    { 
        static void Main(string[] args)
        {
    
            var list = new NewArrayList();
            list.Change += delegate (object sender, EventArgs arg) {
                Console.WriteLine("collect changed {0}", list.Count);
            };
    
            list.Add(1);
            list.Add(2);
            list.Remove(2);
    
        }  
    
    }
