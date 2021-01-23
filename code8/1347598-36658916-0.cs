        #region Documentation
        /// <summary>   Generate a message using a delegate. </summary>
        /// <param name="generateMessage">  Delegate for building message. </param>
        /// <param name="condition">        Whether or not this step is active. </param>
        /// <returns>This form.</returns>
        #endregion
        IFormBuilder<T> Message(MessageDelegate<T> generateMessage, ConditionalDelegate<T> condition = null);
