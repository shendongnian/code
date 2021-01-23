    public class SolrWindsorContainer
    {
        public static WindsorContainer Container { get; set; }
        public void SetContainer(WindsorContainer container){
            Container = container;
        }
        public WindsorContainer GetContainer(){
            return Container;
        }
    }
