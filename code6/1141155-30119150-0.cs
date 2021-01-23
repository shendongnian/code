    public class MonitoringContext {
        public static MonitoringContext CurrentContext = new MonitoringContext();
    
        // handle generating data
        // handle populating data needed for graph
        // handle other action from other forms as well
    }
    
    public class FormGraph : Form{
        // default constructor if you do not have access to MDI
        public FormGraph(){
            this.context = MonitoringContext.CurrentContext;
        }
        public FormGraph(MonitoringContext context){
            this.context = context;
        }
        MonitoringContext context;
    
        // do whatever you want with context
    }
    
    public class FormOther : Form{
        // default constructor if you do not have access to MDI
        public FormOther(){
            this.context = MonitoringContext.CurrentContext;
        }
        public FormOther(MonitoringContext context){
            this.context = context;
        }
        MonitoringContext context;
    
        // do whatever you want with context
        // any changes reflected at the FormGraph
        // because of same reference and mutability
    }
