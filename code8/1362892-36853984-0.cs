    public interface IView
    {
        void DisplayError(string message);
    }
    
    public class MyView : IView
    {
        public string ErrorMessage;
        public void DisplayError(string message)
        {
            ErrorMessage = message;
            System.Diagnostics.Debug.Write(message);
        }
    }
    public delegate void ErrorRaisedEventHandler(object sender, ErrorEventArgs e);
    
    public class Controller
    {
        IView _view;
        Model _model;
        public Controller(IView view, Model model)
        {
            _view = view;
            _model = model;
            _model.ErrorRaised += new ErrorRaisedEventHandler((s,e) => _view.DisplayError(e.GetException().Message));
        }
    }
    
    public class Model
    {
        public event ErrorRaisedEventHandler ErrorRaised;
    
        int monthsAlive = 0;
        public int MonthsAliveInPlanet(int yearBorn, int yearInTime, int monthsInPlanetsYear)
        {
            try
            {
                //Do something bad - divisioin by zero
                monthsAlive = yearInTime - yearBorn / monthsInPlanetsYear;               
            }
            catch (Exception e)
            {
                var eea = new ErrorEventArgs(new Exception(e.Message));
                ErrorRaised(this, new ErrorEventArgs(new Exception(e.Message)));
            }
            return monthsAlive;
        }
    }
