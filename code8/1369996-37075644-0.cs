    public partial class DeviceControl : UserControl
    
    private Device _device = new Device();
    public DeviceControl()
    {
        InitializeComponnents();
        this.DataContext = _device;
    }
    public void SetDevice(Device d)
    {
        //This fails:
        //_device = d;
   
        //This works
        this.DataContext = d;
     }
