    [Serializable] // this is needed to show the object in Inspector
    public class OpenCloseAnimation {}
    
    [Serializable]
    public class Act1_1HomeAwake 
    {
        public OpenCloseAnimation openCloseEyesScript;
        public void CallCoroutine(MonoBehaviour mb)
        {
             mb.StartCoroutine(OpenCloseEyesAnimation());
        }
        public IEnumerator OpenCloseEyesAnimation(){ yield return null;}
    }
