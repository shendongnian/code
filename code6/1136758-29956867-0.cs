    class Communication
    {
       // CAN Status Decalaration
       TPCANStatus gStatus;
       // List of CAN Messages
       TPCANMsg msg1 = new TPCANMsg();
       public Communication()
       {
           msg1.ID = 0x100; 
       }
    }
