        public void NodeNameReceive(string name)
        {
            var evt = this.OnNodeNameReceived;
            if (evt  != null)
            {
                evt (name);
            }
        }
