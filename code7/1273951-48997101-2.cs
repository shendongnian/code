    public class InputControl : MonoBehaviour
    {
       public GameObject cameraOrbit;
       public float rotateSpeed = 8f;
    
       void Update()
       {
           if (Input.GetMouseButton(0))
           {
               float h = rotateSpeed * Input.GetAxis("Mouse X");
               float v = rotateSpeed * Input.GetAxis("Mouse Y");
               
               if (cameraOrbit.transform.eulerAngles.z + v <= 0.1f || cameraOrbit.transform.eulerAngles.z + v >= 179.9f)
                    v = 0;
               cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);
           }
           float scrollFactor = Input.GetAxis("Mouse ScrollWheel");
           if (scrollFactor != 0)
           {
               cameraOrbit.transform.localScale = cameraOrbit.transform.localScale * (1f - scrollFactor);
           }
       }
    }
