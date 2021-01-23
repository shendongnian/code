    public class B
    {
        private A theA;
        public B(A theA)
        {
            this.theA = theA;
        }
    
        private void treeView_NodeMouseClick(object sender, System.EventArgs e)
        {
            theA.textbox = "hello";
        }
    }
