    public class gridRecord    
    {
        private gridIntegerField printRun;
    
        public gridIntegerField PrintRun
        {
          get { return printRun; }
          set { printRun = value; }
        }
    
        //Add a constructor method
        public gridRecord()
        {
           //and instantiate the printRun.
           printRun = new gridIntegerField();
        }    
    }
