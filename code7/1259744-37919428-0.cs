    public class BindableColorCardView: CardView
    {
        private Color m_cCardViewColor;
            public Color CardViewColor
        {
            get { return m_cCardViewColor; }
            set
            {
                m_cCardViewColor = value;
                SetCardBackgroundColor(m_cCardViewColor);
            }
        }
