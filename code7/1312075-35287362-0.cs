    public class HitScript : MonoBehaviour
    {
        private Vector3[] rotations = { new Vextor3(15f,0f,0f),Vector3.zero } ;
        private in index = 0;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(++index >= rotations.Length)index = 0;
                transform.rotation = Quaternion.Euler(rotations[index]);
            }
        }
        //transform.rotation = Quaternion.Lerp(transform.rotation,
          //                      Quaternion.Euler(rotations[index]), Time.deltaTime);
    }
