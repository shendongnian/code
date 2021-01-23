    Sprite myMenuButton = Resources.Load <Sprite> ("sprite_menu_to_load");
    myMenuButton.AddComponent<ClassForSprite>();
    In ClassForSprite
        public class MouseDownScript : MonoBehaviour
        {
            void onAction1(){
             //Code process for action 1
            }
    
            void onAction2(){
             //Code process for action 2
            }
        }
