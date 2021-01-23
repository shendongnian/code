    public class Employee
    {
        private Manager _parentManager;
        public Employee(Manager parentManager)
        {
            _parentManager=parentManager;
        }
        public int ID { get; set; }
        private bool _isEngangedWithWork;
        public bool IsEngagedwithWork
        { 
           get{ return _isEngangedWithWork; } 
           set
              {
                 _isEngangedWithWork=value;
                 if(_isEngangedWithWork)
                  _parentManager.UpdateIsAllEmpEngaged();
               }
        }
    }
