    using UnityEngine;
    
    public class PendulumAccelerometer : MonoBehaviour
    {
        private AccelerometerUtil accelerometerUtil;
    
        // Use this for initialization
        void Start()
        {
            accelerometerUtil = new AccelerometerUtil();
        }
    
        // Update is called once per frame
        void Update()
        {
            Vector3 currentInput = accelerometerUtil.LowPassFiltered();
            //TODO: Create your logic with currentInput (Linear Acceleration)
        }
    }
