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
                MouseLeave += MyScrollBar_MouseLeave;
            }
    
            private void MyScrollBar_MouseEnter(object sender, MouseEventArgs e)
            {
                //Change the width here
                Width = 25.0;
            }
            
            private void MyScrollBar_MouseLeave(object sender, MouseEventArgs e)
            {
                //Change the width back to default value
                Width = ....
            }
