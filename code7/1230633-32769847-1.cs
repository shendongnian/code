    class dbNodeList
    {
        public string nodepath;
        public string nodename;
        public string nodevalue;
        //etc...
    
        public dbNodeList Copy()
        {
            var copy = new dbNodeList();
            copy.nodepath = this.nodepath;
            copy.nodename = this.nodename;
            copy.nodevalue = this.nodevalue;
            //etc...
    
            return copy;
        }
    }
    //used like
    NewThread.nodeList = ThreadManager.nodeList.Copy();
