    public class Example: MonoBehaviour
    {
        public InputField inputField;
        void Start()
        {
        }
    
        void Update()
        {
        }
    
        //Called when Input changes
        private void inputSubmitCallBack()
        {
            Debug.Log("Input Submitted");
            inputField.text = ""; //Clear Inputfield text
            inputField.ActivateInputField(); //Re-focus on the input field
            inputField.Select();//Re-focus on the input field
        }
    
        //Called when Input is submitted
        private void inputChangedCallBack()
        {
            Debug.Log("Input Changed");
        }
    
        void OnEnable()
        {
            //Register InputField Events
            inputField.onEndEdit.AddListener(delegate { inputSubmitCallBack(); });
            inputField.onValueChanged.AddListener(delegate { inputChangedCallBack(); });
        }
    
        void OnDisable()
        {
            //Un-Register InputField Events
            inputField.onEndEdit.RemoveAllListeners();
            inputField.onValueChanged.RemoveAllListeners();
        }
    }
