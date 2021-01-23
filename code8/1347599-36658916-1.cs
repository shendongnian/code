        #region Documentation
        /// <summary>   Given <paramref name="state"/> return a <see cref="PromptAttribute"/> with a template for the message to display. </summary>
        /// <typeparam name="T">    Form state type. </typeparam>
        /// <param name="state">    Form state. </param>
        /// <returns>   A PromptAttribute describing the message to display. </returns>
        #endregion
        public delegate PromptAttribute MessageDelegate<T>(T state);
    
    IFormBuilder<T>
    ...
            #region Documentation
            /// <summary>   Generate a message using a delegate. </summary>
            /// <param name="generateMessage">  Delegate for building message. </param>
            /// <param name="condition">        Whether or not this step is active. </param>
            /// <returns>This form.</returns>
            #endregion
            IFormBuilder<T> Message(MessageDelegate<T> generateMessage, ConditionalDelegate<T> condition = null);
