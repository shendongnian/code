    public interface IUpdateTrigger{
        void updateNotification();
    }
    public class MainWindow : IUpdateTrigger{
        public void updateNotification(){
             //update controls, dispatch if needed
        }
        public void showSecondWindow(){
            SecondWindow second = new SecondWindow(this);
            //code to show the second window like second.show();
        }
    }
    public class SecondWindow{
        private IUpdateTrigger _UpdateTrigger;
        public SecondWindow(IUpdateTrigger trigger){
            _UpdateTrigger = trigger
        }
        public Whatevermethod(){
            _UpdateTrigger.updateNotification();
        }
    }
