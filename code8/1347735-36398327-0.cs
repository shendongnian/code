    class MyForm : Form {
        private volatile bool mouseWheelHandling = false;
        private UserControl userControl;
        
        public void Form_Load(){
            // userControl.Scroll 
            userControl.MouseWheel += (s, a) => {
                if(!mouseWheelHandling) { // capture MouseWheel and Scroll events, only handle 1 times.
                    mouseWheelHandling = true;
                    ThreadPool.QueueUserWorkItem(_=>{
                        var horizontalScroll = userControl.HorizontalScroll.Value;
                        while(true) {
                            Thread.Sleep(100);
                            if(horizontalScroll == userControl.HorizontalScroll.Value) {
                                // Control.Invoke to handle cross-thread action
                                // do action
                                mouseWheelHandling = false; // reset the flag
                                break;
                            }
                            horizontalScroll = userControl.HorizontalScroll.Value;
                        }
                    });
                }
            }
        }
    }
