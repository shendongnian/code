        using UnityEngine;
        using UnityEngine.UI;
        using UnityEngine.EventSystems;
        
        public class OnSliderPointerUpTest : MonoBehaviour, IPointerUpHandler {
        
            Slider slider;
        
            void Start() {
                slider = GetComponent<Slider>();
            }
        
            public void OnPointerUp(PointerEventData eventData) {
                Debug.Log(slider.value);
        
            }
        }
