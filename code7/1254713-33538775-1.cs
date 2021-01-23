        public string TestValue
        {
            get { return testValue; }
            set
            {
                if (testValue != value)
                {
                    testValue = value;
                    // BUGBUG: Warning! This code is not thread-safe; it is possible for
                    // the current thread to check `PropertyChanged` just before some other
                    // thread changes its value to null, and then to try to invoke the handler
                    // just _after_ that other thread changes its value to null. This is fine
                    // if you are sure that the event and property are both only ever accessed
                    // in one single thread. But otherwise, you need to fix this bug, by
                    // following the normal C# idiom for raising events, i.e. store the field
                    // value in a local variable, and then if it's non-null, raise the event
                    // using the local variable's value instead of the event field itself.
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("TestValue"));
                }
            }
        }
