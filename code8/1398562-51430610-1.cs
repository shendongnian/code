    using UnityEngine;
    public class OnChangedCallTester : MonoBehaviour
    {
        public bool UpdateProp = true;
    
        [SerializeField]
        [OnChangedCall("ImChanged")]
        private int myPropVar;
    
        public int MyProperty
        {
            get { return myPropVar; }
            set { myPropVar = value; ImChanged();  }
        }
    
    
        public void ImChanged()
        {
            Debug.Log("I have changed to" + myPropVar);
        }
    
        private void Update()
        {
            if(UpdateProp)
                MyProperty++;
        }
    }
