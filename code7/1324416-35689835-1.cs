    public class ImageFade : MonoBehaviour
    {
        [SerializeField]
        private Image   m_img;
        [SerializeField]
        private float   m_fadeDuration;
        [SerializeField]
        private bool    m_ignoreTimeScale;
    
        private int     m_fadeMultiplier;
        private float   m_alpha;
        private bool    m_requiresUpdate;
    
        public void Start()
        {
            m_fadeMultiplier    = 1;
            m_alpha             = 1f;
        }
    
        public void Update()
        {
            //Toggle subtracting/adding
            if (Input.GetMouseButtonDown(0))
            {
                m_fadeMultiplier = -m_fadeMultiplier;
                m_requiresUpdate = true;
            }
    
            //Update
            if (m_requiresUpdate)
            {
                //Fade
                m_alpha = Mathf.Clamp(m_alpha + (m_fadeMultiplier * (Time.deltaTime / m_fadeDuration)), 0f, 1f);
                m_img.canvasRenderer.SetAlpha(m_alpha);
    
                //Finished fading
                if (m_alpha == 0f || m_alpha == 1f)
                    m_requiresUpdate = false;
            }
        }
    }
