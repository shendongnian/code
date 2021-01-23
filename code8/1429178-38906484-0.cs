    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    
    public class YourScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Transform LoadingBar;
        public Transform TextIndicator;
        [SerializeField]
        private float currentAmount;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float numSec;
    
    
        bool isPressed = false;
    
        public void OnPointerDown(PointerEventData eventData)
        {
            //  someCode();
            Debug.Log("Mouse Down");
            isPressed = true;
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Mouse Up");
            isPressed = false;
        }
    
        void Update()
        {
            if (isPressed)
            {
                someCode();
            }
    
        }
        void someCode()
        {
            if (currentAmount < 100)
            {
                currentAmount += speed * Time.deltaTime;
    
    
            }
            else if (currentAmount > 100)
            {
                currentAmount = 0;
    
                numSec += 1;
            }
            LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
            TextIndicator.GetComponent<Text>().text = ((int)numSec).ToString() + "s";
        }
    }
