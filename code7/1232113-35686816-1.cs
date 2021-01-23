        public void PersistChanges()
        {
            var saveTask = new Task(() => PersistChangesAsync());
            saveTask.Start();
        }
