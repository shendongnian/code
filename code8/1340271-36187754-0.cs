    public class DelegateContainer : IDisposable{
        private IList<Func<string, int>> container = null;
        public DelegateContainer(){
            this.container = new List<Func<string,int>>();
        }
        public void Dispose(){
             this.container.Clear();
             this.container = null;
        }
        public bool AddMethod(Func<string, int> func){
           if(func != null && this.container.Contains(func) == false){
               this.container.Add(func);
               return true;
           }
           return false;
        }
        public bool RemoveMethod(Func<string, int>func){
           if(func != null && this.container.Contains(func) == true){
               this.container.Remove(func);
               return true;
           }
           return false;
        }
        public int GetFullValue(){
           int total = 0;
           foreach(var meth in this.container){
               if(meth != null) { total += meth(""); }
           }
           return total;
        }
        public IEnumerable<int> GetAllValues(){
            IList <int> list = new List<int>();
            foreach(var meth in this.container){
               if(meth != null) { list.Add(meth("");); }
           }
           return list as IEnumerable<int>;
        }
    } 
