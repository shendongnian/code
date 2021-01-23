        /// <summary>
        /// Gets the result by invoking the <see cref="LoadAction"/> if not already loaded.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that can be used to iterate through the collection.
        /// </returns>
        protected virtual IEnumerable<T> GetResult()
        {
            if (IsLoaded)
                return _result;
            // no load action, run query directly
            if (LoadAction == null)
            {
                _isLoaded = true;
                _result = _query as IEnumerable<T>;
                return _result;
            }
            // invoke the load action on the datacontext
            // result will be set with a callback to SetResult
            LoadAction.Invoke();
            return _result ?? Enumerable.Empty<T>();
        }
