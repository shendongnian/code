    class YourClassName
    {
        int b;
        void Start()
        {
            StartCoroutine("MyEvent");
            b = 100; //some number
        }
 
        private IEnumerator MyEvent()
        {
            while(true)
            {
                yield return new WaitForSeconds(1); // wait a second
                b--;
            }
        }
    }
