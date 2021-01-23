        public void AddErrors(string path, IEnumerable<Exception> errors, bool nest = true)
        {
            var exceptions = errors as IList<Exception> ?? errors.ToList();
            var nestedPath = path.Split('.').ToList();
            if (nestedPath.Count > 1 && nest)
            {
                var tail = string.Join(".", nestedPath.Skip(1));
                // Try and get a child property as Maybe<INotifyDataExceptionInfo> 
                // and if it exists pass the error
                // downwards after stripping off the first part of
                // the path.
                var notifyDataExceptionInfo = this.TryGet<INotifyDataExceptionInfo,INotifyDataExceptionInfo>(nestedPath[0]);
                if(notifyDataExceptionInfo.IsSome)
                    notifyDataExceptionInfo.Value.AddErrors(tail, exceptions);
            }
            _Errors.RemoveKey(path);
            foreach (var error in exceptions)
            {
                _Errors.Add(path, error);
            }
            RaiseErrorEvents(path);
        }
