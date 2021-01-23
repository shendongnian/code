    public class newspawn_real : MonoBehaviour
    {
        unsafe static void SquarePtrParam(int* p)
        {
            *p *= *p;
        }
    
        void Start()
        {
            unsafe
            {
                int i = 5;
                // Unsafe method: uses address-of operator (&):
                SquarePtrParam(&i);
                Debug.Log(i);
            }
        }
    }
