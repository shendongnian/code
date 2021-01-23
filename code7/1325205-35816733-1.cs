    [RequireComponent(typeof(Animator))]
    public class TimelineElement : MonoBehaviour
    {
        private Animator m_animator;
    
        public void Start()
        {
            m_animator = GetComponent<Animator>();
        }
    
        public void SetVisible(bool p_visible)
        {
            m_animator.SetBool("Visible", p_visible);
        }
    }
