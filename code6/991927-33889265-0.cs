        public IAsyncResult BeginSomeMethod(string parameter1, string parameter2, AsyncCallback callback, object state)
        {
            var task = Task<List<int>>.Factory.StartNew((res) => my_function(state, parameter1, parameter2), state);
            return task.ContinueWith(res => callback(task));
        }
        public List<int> EndSomeMethod(IAsyncResult result)
        {
            return ((Task<List<int>>)result).Result;
        }
        private List<int> my_function(object state, string parameter1, string parameter2)
        {
			//implementation goes here
		}
