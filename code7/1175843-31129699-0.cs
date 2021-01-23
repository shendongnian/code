      public class ClickAction : MonoBehaviour {
            public string on=null;
            public Destroyer destroy;
            void Update () {
                    if (Input.GetMouseButtonDown (0)) {
                    Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
                    RaycastHit rhInfo;
                    bool didHit = Physics.Raycast (toMouse, out rhInfo, 500.0f);
                    if (didHit) {
                         Destroy(rhInfo.collider.gameObject);
        
                             }
                          }
                        } 
                     }
