    public class Win:MonoBehaviour{
        public EventHandler<System.EventArg> RaiseUpdateScore;
        protected void OnUpdateScore(EventArg args){
            if(RaiseUpdateScore != null){
               RaiseUpdateScore(this, args);
            }
        }
    
        public void SomeAction(){
           if(someCondition){
                OnUpdateScore(null);
           }
        }
        void OnDestroy(){ RaiseUpdateScore = null; }
    }
