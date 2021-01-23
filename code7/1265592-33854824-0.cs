        public new int Value
        {
            set
            {
                // other things you do here...
                base.Value = value; // this was missing
            }
        }
