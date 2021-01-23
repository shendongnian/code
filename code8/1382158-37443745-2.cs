    public abstract class BaseMyThirdParty<T> where T : class
    {
        public T OriginalObject { get; set; }
       
        public virtual T LoadObject(string param)
        { // Load object }
    
        public virtual void DeleteObject(string param)
        { // Deleteobject }
    
        public virtual T UpdateObject(string param)
        { // Update object }
    }
