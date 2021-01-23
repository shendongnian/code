    class MyDemoVM{
        private Model[] items;
        private readonly ISomeDataService service;
        private readonly IDispatcherService dispService;
        public MyDemoVM(){
            service=new SomeDataServiceImpl();
            dispService=new DispatcherService();
            //i use ctor injection here in order to break the dependency on SomeDataServiceImpl
        }
        public Model[] Items{
            get{
                if(items==null)GetItems();
                return items;
            }
            set{
                if(items==value)return;
                items=value;
                NotifyChanged("Items");
            }
        }
        private void GetItems(){
            service.GetModelItems((res,ex)=>{
                //this is on a different thread so you need to synchronize
                dispService.Dispatch(()=>{
                    Items=res;
                });
            });
        }
    }
