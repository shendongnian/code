    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
    
        public enum PanelType
        {
            HomeScreen, Settings
        }
        public partial class CustomPanel : Panel
        {
    
            public PanelType PanelType { get; set; }
    
        }
    }
