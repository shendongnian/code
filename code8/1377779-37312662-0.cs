    public class ButtonClickScript : MonoBehavior, IPointerClickHandler
    {
        public int waterBucketAmnt;
        void OnPointerClick() 
        {
            if (waterBucketAmnt < 3)
                waterBucketAmnt++;
        }
    }
