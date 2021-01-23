    public class ImageFade : MonoBehaviour
    {
        [SerializeField]
        private Image m_img;
        [SerializeField]
        private float m_fadeDuration;
        [SerializeField]
        private bool m_ignoreTimeScale;
    
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
                m_img.CrossFadeAlpha(0f, m_fadeDuration, m_ignoreTimeScale);
            if (Input.GetMouseButtonDown(1))
                m_img.CrossFadeAlpha(1f, m_fadeDuration, m_ignoreTimeScale);
        }
    }
