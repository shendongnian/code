    class Master
    {
      public Master(string ip)
      {
        InitializeComponent();
        _droneClient = new DroneClient("192.168.1." + ip);
        ip_drone = "192.168.1." + ip; 
        Point p2 = arena.posicao_desej();
        posicao_desejada = p2;
    }
      public string ip_dron()
      {
         return ip_drone;
      }
    }
