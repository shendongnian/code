    /// <summary>
    /// Helper class to add weak handlers to events of predefined event handler, i.e. PropertyChagnedEventHandler
    /// </summary>
    public static class WeakEventHandler<TEventHandler, TEventArgs>
        where TEventHandler : class // delegate
        // where TEventArgs : EventArgs // work with structs not derived from EventArgs, i.e. DependencyPropertyChangedEventArgs
    {
        /// <summary>
        /// Registers an predefined event handler that works with a weak reference to the target object.
        /// Access to the event and to the real event handler is done through lambda expressions.
        /// The code holds strong references to these expressions, so they must not capture any
        /// variables!
        /// </summary>
        /// </example>
        public static WeakEventHandler Register<TEventSource, TEventListener>(
            TEventSource senderObject,
            Action<TEventSource, TEventHandler> registerEvent,
            Action<TEventSource, TEventHandler> deregisterEvent,
            TEventListener listeningObject,
            Action<TEventListener, object, TEventArgs> forwarderAction
        )
            where TEventSource : class
            where TEventListener : class
        {
            if (senderObject == null)  throw new ArgumentNullException("senderObject");
            if (listeningObject == null)  throw new ArgumentNullException("listeningObject");
            WeakEventHandler.VerifyDelegate(registerEvent, "registerEvent");
            WeakEventHandler.VerifyDelegate(deregisterEvent, "deregisterEvent");
            WeakEventHandler.VerifyDelegate(forwarderAction, "forwarderAction");
            WeakEventHandler weh = new WeakEventHandler(listeningObject);
            TEventHandler eh = MakeDeregisterCodeAndWeakEventHandler(weh, senderObject, deregisterEvent, forwarderAction);
            registerEvent(senderObject, eh);
            return weh;
        }
        static TEventHandler MakeDeregisterCodeAndWeakEventHandler
            <TEventSource, TEventListener>
            (
                WeakEventHandler weh,
                TEventSource senderObject,
                Action<TEventSource, TEventHandler> deregisterEvent,
                Action<TEventListener, object, TEventArgs> forwarderAction
            )
            where TEventSource : class
            where TEventListener : class
        {
            Action<object, TEventArgs> eventHandler = (sender, args) =>
            {
                TEventListener listeningObject = (TEventListener)weh.listeningReference.Target;
                if (listeningObject != null) forwarderAction(listeningObject, sender, args);
                else weh.Deregister();
            };
            weh.deregisterCode = delegate
            {
                deregisterEvent(senderObject, ConvertDelegate(eventHandler));
            };
            return ConvertDelegate(eventHandler);
        }
        static TEventHandler ConvertDelegate(Delegate source)
        {
            if (source == null) return null;
            Delegate[] delegates = source.GetInvocationList();
            if (delegates.Length == 1) return Delegate.CreateDelegate(typeof(TEventHandler), delegates[0].Target, delegates[0].Method) as TEventHandler;
            for (int i = 0; i < delegates.Length; i++) delegates[i] = Delegate.CreateDelegate(typeof(TEventHandler), delegates[i].Target, delegates[i].Method);
            return Delegate.Combine(delegates) as TEventHandler;
        }
    }
