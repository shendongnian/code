        using UnityEngine;
        using UnityEngine.UI;
        using UnityEngine.EventSystems;
        
        public class OnSliderUpTest : MonoBehaviour, IPointerUpHandler {
        
            Slider slider;
        
            void Start() {
                slider = GetComponent<Slider>();
            }
        
            public void OnPointerUp(PointerEventData eventData) {
                Debug.Log(slider.value);
        
            }
        }
