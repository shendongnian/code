    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public class ExPanel : Panel
    {
        const int WS_EX_LAYOUTRTL = 0x400000;
        const int WS_EX_NOINHERITLAYOUT = 0x100000;
        private bool rightToLeftLayout = false;
        [Localizable(true)]
        public bool RightToLeftLayout
        {
            get { return rightToLeftLayout; }
            set
            {
                if (rightToLeftLayout != value)
                {
                    rightToLeftLayout = value;
                    this.RecreateHandle();
                }
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP;
                CP = base.CreateParams;
                if (this.RightToLeftLayout &&
                    this.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                    CP.ExStyle = CP.ExStyle | WS_EX_LAYOUTRTL | WS_EX_NOINHERITLAYOUT;
                return CP;
            }
        }
    }
