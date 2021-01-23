    public class DesignerIssuesModel
    {
        private readonly BehaviorService m_BehaviorService;
        private readonly Adorner m_Adorner = new Adorner();
        private readonly Dictionary<Control, MyGlyph> m_Glyphs = new Dictionary<Control, MyGlyph>();
        public IDesignerHost DesignerHost { get; private set; }
        
        public DesignerIssuesModel(IDesignerHost designerHost)
        {
            DesignerHost = designerHost;
            m_BehaviorService = (BehaviorService)DesignerHost.RootComponent.Site.GetService(typeof(BehaviorService));
            m_BehaviorService.Adornders.Add(m_Adorner);
        }
        public void AddIssue(Control control)
        {
            if (!m_Glyphs.ContainsKey(control))
            {
                MyGlyph g = new MyGlyph(m_BehaviorService, control);
                m_Glyphs[control] = g;
                m_Adorner.Glyphs.Add(g);
            }
            m_Glyphs[control].Issues += 1; 
        }
        public void RemoveIssue(Control control)
        {
            if (!m_Glyphs.ContainsKey(control)) return;
            MyGlyph g = m_Glyphs[control];
            g.Issues -= 1;
            if (g.Issues > 0) return;
            m_Glyphs.Remove(control);
            m_Adorner.Glyphs.Remove(g);
        }
    }
