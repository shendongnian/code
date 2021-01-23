    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Demo
    {
        public class MyTabControl : TabControl
        {
            public MyTabControl()
            {
                SizeMode = TabSizeMode.Fixed; 
                ItemSize = new Size(224, 20);
            }
