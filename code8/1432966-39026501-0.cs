    using UnityEngine.UI;
    
    public class Shop : MonoBehaviour 
    {
        public GameObject shopToShow;
    
        public Button StoreButton;
    
        void OnEnable()
        {
            //Register Button Events
            StoreButton.onClick.AddListener(() => storeButtonCallBack());
    
        }
    
        private void storeButtonCallBack()
        {
            Debug.Log("Shop Button Clicked!");
            shopToShow.SetActive(true);
        }
    
        void OnDisable()
        {
            //Un-Register Button Events
            StoreButton.onClick.RemoveAllListeners();
        }
    }
