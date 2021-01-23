    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class instantiate : MonoBehaviour
    {
        public GameObject cubePrefab;
        public Slider cubeSlider;
        public Button instantiateButton;
    
        public float speed = 0f;
        public float pos = 0f;
    
    
        private Transform currentObjectToDrag = null;
    
        // Use this for initialization
        void Start()
        {
            //Set Slider Values
            cubeSlider.minValue = 0f;
            cubeSlider.maxValue = 50f;
            cubeSlider.value = 0f;
    
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    GameObject objHit = hit.collider.gameObject;
                    Debug.Log("We Clicked on : " + objHit.name);
    
                    //Check if this is cube
                    if (objHit.CompareTag("Cube"))
                    {
                        Debug.Log("Cube selected. You can now drag the Cube with the Slider!");
                        //Change the current GameObject to drag
                        currentObjectToDrag = objHit.transform;
                    }
                }
            }
        }
    
        public void instantiateCube()
        {
            //Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(cubePrefab, new Vector3(-15.1281f, 0.67f, 7.978208f), Quaternion.identity);
        }
    
        public void rotatess(float newspeed)
        {
            speed = newspeed;
    
        }
    
        public void positions(float newpos)
        {
            pos = newpos;
        }
    
        //Called when Instantiate Button is clicked
        void instantiateButtonCallBack()
        {
            Debug.Log("Instantiate Button Clicked!");
            instantiateCube();
        }
    
        //Called when Slider value changes
        void sliderCallBack(float value)
        {
            Debug.Log("Slider Value Moved : " + value);
    
            //Move the Selected GameObject in the Z axis with value from Slider
            if (currentObjectToDrag != null)
            {
                currentObjectToDrag.position = new Vector3(0, 0, value);
                Debug.Log("Position changed!");
            }
        }
    
        //Subscribe to Button and Slider events
        void OnEnable()
        {
            instantiateButton.onClick.AddListener(instantiateButtonCallBack);
            cubeSlider.onValueChanged.AddListener(delegate { sliderCallBack(cubeSlider.value); });
        }
    
        //Un-Subscribe to Button and Slider events
        void OnDisable()
        {
            instantiateButton.onClick.RemoveListener(instantiateButtonCallBack);
            cubeSlider.onValueChanged.RemoveListener(delegate { sliderCallBack(cubeSlider.value); });
        }
    }
