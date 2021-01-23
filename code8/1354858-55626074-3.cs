    using UnityEngine.UI;
    public class Example : MonoBehaviour 
    {
        public UnityEngine.UI.Button Button;
        public void onClickEvent() 
        {
            //Hide button
            Button.gameObject.SetActive(false);
        }
    }
