    class UserInputController : MonoBehaviour {
        //These can be set from the inspector and controlled from within the script
        public InputField PressureInput;  
        public InputField DrillpipeInput; 
        // It would be better to pass this reference through
        // the inspector instead of searching for it every time
        // an input changes
        public DataManager dataManager;
        private void Start() {
            // Here you can setup your event handling for both
            // the PressureInput and DrillpipeInput
        }
    }
