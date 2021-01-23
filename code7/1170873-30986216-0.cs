    using System;
    using System.Windows.Forms;
    
    namespace NoDblClickPic
    {
        public partial class NoDblClickPicControl : PictureBox
        {
            private const int CS_DBLCLKS = 0x8;
    
            public NoDblClickPicControl()
            {
            }
    
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ClassStyle &= ~CS_DBLCLKS;
                    return cp;
                }
            }
        }
    }
