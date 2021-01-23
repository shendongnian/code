    [Serializable]
    public class MyPanelInfo 
    {
        public PanelInfo panel1;
        public PanelInfo panel2;
        public PanelInfo panel3;
        public PanelInfo panel4;
        public Image image;
        public string nameLabel;
    
        public MyPanelInfo()
        {
    
        }
    }
    
    [Serializable]
    public class PanelInfo
    {
    	public string id;
    	public string name;
    }
