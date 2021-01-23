    public class MyActivity : Activity {
    
        ...
    
        private class broadCastReceiver : BroadcastReceiver {
            private MyActivity act;
    
            public broadCastReceiver (MyActivity act) {
                this.act = act;
            }
    
            private void updateUI (Intent intent) {
                TextView startx = act.FindViewById<TextView> (Resource.Id.startx);
            }
        }
    }
