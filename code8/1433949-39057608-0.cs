    private myClass[] arrayms = new myClass[5];
    public void _TasksClassCreator()
    {
         foreach (var ms in arrayms )
         {
              ms.ScheduleName = SName;
              .
              .
              .
         }
    }
    public void _StartTask()
    {
        foreach (myClass ms in arrayms) 
        {
          if (ms.ScheduleState)
            Task.Factory.StartNew(() => ms.Start());
        }
    }
    public sealed class myClass
    {
        public void Start()
        {
            _TBTask();
        }
        private void _TBTask()
        {
             while(true)
             {
                  ...//Conflict here
                  // this function always running and reporting result...
                  //log here
             }
        }
        private string _ScheduleName;
        public string ScheduleName
        {
            get
            {
                return _ScheduleName;
            }
            set
            {
                _ScheduleName = value;
            }
            .
            .
            .
        }
    }
