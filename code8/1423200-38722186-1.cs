        /// <summary>
        /// The actual code which invokes the body of the task. This can be overriden in derived types.
        /// </summary>
        internal virtual void InnerInvoke()
        {
            // Invoke the delegate
            Contract.Assert(m_action != null, "Null action in InnerInvoke()");
            var action = m_action as Action;
            if (action != null)
            {
                action();
                return;
            }
            var actionWithState = m_action as Action<object>;
            if (actionWithState != null)
            {
                actionWithState(m_stateObject);
                return;
            }
            Contract.Assert(false, "Invalid m_action in Task");
        }
