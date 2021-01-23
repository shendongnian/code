        protected void UpdateClusterDescription(ClusterDescription newClusterDescription)
        {
            ClusterDescription oldClusterDescription = null;
            TaskCompletionSource<bool> oldDescriptionChangedTaskCompletionSource = null;
            Console.WriteLine($"Before UpdateClusterDescription {_descriptionChangedTaskCompletionSource?.Task.Id}, {_descriptionChangedTaskCompletionSource?.Task?.GetHashCode().ToString("F8")}");
            lock (_descriptionLock)
            {
                oldClusterDescription = _description;
                _description = newClusterDescription;
                oldDescriptionChangedTaskCompletionSource = _descriptionChangedTaskCompletionSource;
                _descriptionChangedTaskCompletionSource = new TaskCompletionSource<bool>();
            }
            OnDescriptionChanged(oldClusterDescription, newClusterDescription);
            Console.WriteLine($"Setting UpdateClusterDescription {oldDescriptionChangedTaskCompletionSource?.Task.Id}, {oldDescriptionChangedTaskCompletionSource?.Task?.GetHashCode().ToString("F8")}");
            oldDescriptionChangedTaskCompletionSource.TrySetResult(true);
            Console.WriteLine($"Set UpdateClusterDescription {oldDescriptionChangedTaskCompletionSource?.Task.Id}, {oldDescriptionChangedTaskCompletionSource?.Task?.GetHashCode().ToString("F8")}");
        }
        private void WaitForDescriptionChanged(IServerSelector selector, ClusterDescription description, Task descriptionChangedTask, TimeSpan timeout, CancellationToken cancellationToken)
        {
            using (var helper = new WaitForDescriptionChangedHelper(this, selector, description, descriptionChangedTask, timeout, cancellationToken))
            {
                Console.WriteLine($"Waiting {descriptionChangedTask?.Id}, {descriptionChangedTask?.GetHashCode().ToString("F8")}");
                var index = Task.WaitAny(helper.Tasks);
                helper.HandleCompletedTask(helper.Tasks[index]);
            }
        }
