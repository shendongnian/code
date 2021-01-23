    public class Control {
        public EventHandler OnEnter;
        public EventHandler OnLeave;
        public void TriggerEnter() {
            if (OnEnter != null) {
                OnEnter(null, EventArgs.Empty);
            }
        }
        public void TriggerLeave() {
            if (OnLeave != null) {
                OnLeave(null, EventArgs.Empty);
            }
        }
    }
    class Program {
        public static EventHandler OnBufferedEvent;
        static void Main(string[] args) {
            bool hasEntered = false;
            Timer timer = new Timer(2000);
            OnBufferedEvent += (sender, eventArgs) => Console.WriteLine("My buffered event has fired");
            timer.Elapsed += (sender, e) =>{
                if (!hasEntered) {
                    if (OnBufferedEvent != null) {
                        OnBufferedEvent(null, EventArgs.Empty);
                    }
                }
            };
            
            Control control = new Control {
                OnEnter = (sender, eventArgs) => {
                    hasEntered = true;
                    Console.WriteLine("On enter event has fired");
                },
                OnLeave = (sender, eventArgs) => {
                    hasEntered = false;
                    timer.Start();
                    Console.WriteLine("On leave event has fired");
                }
            };
             
            control.TriggerLeave();
            Thread.Sleep(1000);
            control.TriggerEnter();
            Thread.Sleep(100);
            control.TriggerLeave();
            Thread.Sleep(2500);
        }
    }
