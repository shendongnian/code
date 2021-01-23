        public void RemoveOnItemKeyChangedHandlers()
        {
            foreach (var cwEntity in this)
            {
                cwEntity.KeyChanged -= new System.EventHandler<CodeFluent.Runtime.Utilities.KeyChangedEventArgs<System.Guid>>(this.OnItemKeyChanged);
            }
        }
