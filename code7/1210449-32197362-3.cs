    /*version 1.52*/
    public class Bootstrapper : BootStrapper<LoginViewModel>{
    
        public Bootstrapper(){
         
            Start();
        }
        protected override Configure(){
            
            /* -- your Ninject configurations -- */
        }
        protected override object GetInstance(Type service, string Key){
            if(service == null)
               throw new ArgumentNullException("Service");
           return _kernel.Get(service);
        }
     
        protected override IEnumerable<object> GetAllInstances(Type service){
          return _kernel.GetAll(service);
        }
        protected override void BuildUp(object instance){
          _kernel.Inject(instance);
        }
     
        protected override void OnExit(object sender, EventArgs e)
        {
            kernel.Dispose();
            base.OnExit(sender, e);
        }
     
     }
