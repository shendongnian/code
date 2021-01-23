    public class MyUserControlVm
    {
        public Uri Path { get; set; }
    
        public MyUserControlVm(string url)
        {
            Path = new Uri(url);
        }
    
        public void VmAction()
        {
            
        }
    }
