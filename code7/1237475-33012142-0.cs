    //// part of the library code for message passing ////////////////////////////
    
    public interface IMessage{}
 
    public interface ISubscribe
    {
        void Handle(IMessage msg);
    }
    
    /// <summary>
    /// A base class for IMessage subscribers who are only
    /// interested in a particular message type. 
    /// The Handle() funciton performs the type check and 
    /// calls HandleImpl() if and only if the message has the proper type
    /// given in the type parameter. Derived 
    /// subscribers only need to implement HandleImpl().
    /// </summary>
    /// <typeparam name="MessageT">The message type the derived subscriber
    /// is interested in.</typeparam>
    public abstract class SubscriberBaseT<MessageT>: ISubscribe 
           where MessageT: class, IMessage
    {
        /// <summary>
        /// Check whether the message is of the type we are interested in.
        /// If yes, call our handling implementation.
        /// Note: No knowledge of specific message types or internals.
        /// </summary>
        /// <param name="msg">The IMessage to check</param>
        public void Handle(IMessage msg)
        {
            var messageTmsg = msg as MessageT;
            if( msg != null )
            {
                HandleImpl(messageTmsg);
            }
        }
    
        /// <summary>
        /// To be implemented by derived classes. 
        /// Do something with the message type we are concerned about.
        /// </summary>
        /// <param name="concreteMsg">A message of the type we are
        /// interested in.</param>
        public abstract void HandleImpl(MessageT concreteMsg);
    }
    //// user code file1.cs  ////////////////////////////
    
    /// <summary>
    /// A user defined message
    /// </summary>
    public class Msg1T: IMessage { /***/ }
    
    /// <summary>
    /// A user defined handler interested only in Msg1T messages.
    /// Note: No knowledge of other message types.
    /// </summary>
    public class Msg1SubscrT: SubscriberBaseT<Msg1T>
    {
        public override void HandleImpl(Msg1T msg)
        {
            // do something with this particular message
        }
    }
 
    //// user code file2.cs  ////////////////////////////
    
    /// <summary>
    /// Another user defined message
    /// </summary>
    public class Msg2T: IMessage { /***/ }
    
    /// <summary>
    /// Another user defined handler,
    /// interested only in Msg2T messages
    /// </summary>
    public class Msg2SubscrT: SubscriberBaseT<Msg2T>
    {
        public override void HandleImpl(Msg2T msg)
        {
            // do something with this Msg2T
        }
    }
    
    //// user code file3.cs  ////////////////////////////
    // ...
