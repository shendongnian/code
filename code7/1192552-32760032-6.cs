    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class TabControlEx : TabControl {
        private Point downPos;
        private Form draggingHost;
        private Rectangle draggingBounds;
        private Point draggingPos;
    
        public TabControlEx() {
            this.SetStyle(ControlStyles.UserMouse, true);
        }
    }
