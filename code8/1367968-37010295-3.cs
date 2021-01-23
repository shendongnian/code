        using UnityEngine;
        using UnityEngine.UI;
        using UnityEngine.EventSystems;
        
        public class OnSliderPointerUpTest : MonoBehaviour, IPointerUpHandler {
        
            Slider slider;
            float oldValue;
       
            void Start() {
                slider = GetComponent<Slider>();
                oldValue = slider.value;
            }
        
            public void OnPointerUp(PointerEventData eventData) {
                if(slider.value != oldValue) {
                    Debug.Log("Slider value changed from " + oldValue + " to " + slider.value);
                    oldValue = slider.value;
                }
            }
        }
