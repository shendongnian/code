    Public Class UserControl(){
        private MakeEvent makeEvent;
        Public MyClass(MakeEvent makeEvent)
        {
            this.makeEvent = makeEvent;
            Switch.armySwitchCloseButton.Click += armySwitchClose;
        }
    
        void armySwitchClose(object sender, EventArgs e)
        {
            makeEvent.armySwitchClose(sender,e);
        }
    }
    
    Public Class MakeEvent() {
    
        void armySwitchClose(object sender, EventArgs e)
        {
            //the real implementation
        }
    }
