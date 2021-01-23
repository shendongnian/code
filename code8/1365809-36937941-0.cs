        /// <summary>
        /// My custom ScrollBar
        /// </summary>
        public class MyScrollBar:ScrollBar
        {
           
            /// <summary>
            /// Subscribe to the events you need
            /// </summary>
            public MyScrollBar()
            {
                MouseEnter += MyScrollBar_MouseEnter;
            }
    
            private void MyScrollBar_MouseEnter(object sender, MouseEventArgs e)
            {
                //Change the width here
                Width = 25.0;
            }
