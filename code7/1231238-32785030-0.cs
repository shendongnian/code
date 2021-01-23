        Int32 _ActiveThreadCount = 0;
        delegate void SetTextCallback(String text);
        public Int32 ActiveThreadCount
        {
            get 
            { 
                return _ActiveThreadCount; 
            }
            set 
            {
                _ActiveThreadCount = value;
                SetText(value.ToString());
            }
        }
        private void OnThreadCallback(Object state)
        {
            System.Threading.Thread.Sleep(1000);
            ActiveThreadCount--;
        }
        private void SetText(String text)
        {
            if (label2.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(SetText);
                this.Invoke(callback, text);
            }
            else
            {
                this.label2.Text = text;
            }
        }
