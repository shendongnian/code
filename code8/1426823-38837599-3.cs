    public class ObjectTest : MonoBehaviour
    {
        Transform current_transform;
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Raycast from mouse cursor pos
                RaycastHit rayCastHit;
                Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(rayCast, out rayCastHit))
                {
                    if (rayCastHit.transform.GetComponent<IClickable>() != null)
                    {
                        rayCastHit.transform.GetComponent<IClickable>().Show_status(true);
                        current_transform.GetComponent<IClickable>().Show_status(false);
                        current_transform = rayCastHit.transform;
                    }
                }
            }
        }
    }
