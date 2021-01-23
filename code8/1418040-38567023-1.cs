    public class ExampleClass : MonoBehaviour {
        
        void FixedUpdate() {
           for (int i = 0; i < Input.touchCount; ++i) {
               Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch(i).Position);
               RaycastHit ballHit;
               if(Physics.Raycast (camRay, out ballHit, camRayLength, ballMask))
               {
                   if (Input.GetTouch(i).phase == TouchPhase.Stationary) {
                       power += speed + Time.deltaTime;             
                   }
                   else if (Input.GetTouch(i).phase == TouchPhase.Ended) {
                       LauchBall(power);
                       power = 0;        
                   }
               }
            }
        }
    }
