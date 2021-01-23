    class Abc {
        internal int a;
        private readonly MyMessageBox messageBox;
        
        public Abc(MyMessageBox messageBox) {
            this.messageBox = messageBox;
        }
    
        public void MyMethod() {
            if (messageBox.Show("Sure?", "Title", MessageBoxButtons.YesNo) == DialogResult.Yes)
                a = 1;
            else
                a = 0;
        }
    }
