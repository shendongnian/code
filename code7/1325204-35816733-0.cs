    [RequireComponent(typeof(Slider))]
    public class TimelineController : MonoBehaviour
    {
        private RectTransform       m_transform;
        private Slider              m_slider;
        private TimelineElement[]   m_elements;
        private Vector3             m_tempPosition;
    
        public void Start()
        {
            m_transform         = GetComponent<RectTransform>();
            m_slider            = GetComponent<Slider>();
            m_elements          = GetComponentsInChildren<TimelineElement>();
            m_slider.maxValue   = m_elements.Length - 1;
            m_tempPosition      = m_elements[0].GetComponent<RectTransform>().localPosition;
    
            for(int element = 0; element < m_elements.Length; element++)
            {
                m_tempPosition.x = (m_transform.rect.width - 20f) * ((float)element / (m_elements.Length - 1));
                Debug.Log(m_transform.rect.width);
                m_elements[element].GetComponent<RectTransform>().localPosition = m_tempPosition;
            }
    
            m_elements[0].SetVisible(true);
        }
    
        public void OnChange()
        {
            m_elements[(int)m_slider.value].SetVisible(true);
    
            for (int element = 0; element < m_elements.Length; element++)
            {
                if (element != (int)m_slider.value)
                    m_elements[element].SetVisible(false);
            }
        }
    }
