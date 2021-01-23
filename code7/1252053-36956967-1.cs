    public class ConcreteApplicationSettings : IApplicationSettings {
        public string this[string keyToReturn] {
            get { 
                return HttpContext.Current.Application[keyToReturn]; 
            }
            set {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application[keyToUpdate] = value;
                HttpContext.Current.Application.UnLock();
            }
        }    
    }
