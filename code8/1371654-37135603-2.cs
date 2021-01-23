    public class RandomGen : MonoBehaviour
    {
        static private System.Random _random = new System.Random();
    
    
        public void Shuffle(int[] array)
        {
            int p = array.Length;
            for (int n = p - 1; n > 0; n--)
            {
                int r = _random.Next(0, n);
                int t = array[r];
                array[r] = array[n];
                array[n] = t;
            }
        }
    }
