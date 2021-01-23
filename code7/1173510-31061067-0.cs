        private void SomeMethod()
        {
            // do something
        }
         public bool Execute(Action act, Action<Exception> onErrorCallback)
            {
                var res = true;
                try
                {
                    act();
                }
                catch (Exception ex)
                {
                    res = false;
                    onErrorCallback(ex);
                }
                return res;
            }
