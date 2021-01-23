     private void RaisePropertyChangingUnsafe(string propertyName)
            {
                PropertyChangingEventHandler handler = PropertyChanging;
                if (handler != null)
                {
                    handler(this, new PropertyChangingEventArgs(propertyName));
                }
            }
