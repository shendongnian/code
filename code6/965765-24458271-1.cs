    /// <summary>
    /// Registers a recipient for a type of message TMessage.
    ///             The action parameter will be executed when a corresponding
    ///             message is sent. See the receiveDerivedMessagesToo parameter
    ///             for details on how messages deriving from TMessage (or, if TMessage is an interface,
    ///             messages implementing TMessage) can be received too.
    /// 
    /// <para>
    /// Registering a recipient does not create a hard reference to it,
    ///             so if this recipient is deleted, no memory leak is caused.
    /// </para>
    /// 
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the recipient registers
    ///             for.</typeparam><param name="recipient">The recipient that will receive
    ///             the messages.</param><param name="token">A token for a messaging
    ///             channel. If a recipient registers using a token, and a sender sends
    ///             a message using the same token, then this message will be delivered to
    ///             the recipient. Other recipients who did not use a token when
    ///             registering (or who used a different token) will not get the message.
    ///             Similarly, messages sent without any token, or with a different
    ///             token, will not be delivered to that recipient.</param><param name="receiveDerivedMessagesToo">If true, message types deriving from
    ///             TMessage will also be transmitted to the recipient. For example, if a SendOrderMessage
    ///             and an ExecuteOrderMessage derive from OrderMessage, registering for OrderMessage
    ///             and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    ///             and ExecuteOrderMessage to the recipient that registered.
    /// 
    /// <para>
    /// Also, if TMessage is an interface, message types implementing TMessage will also be
    ///             transmitted to the recipient. For example, if a SendOrderMessage
    ///             and an ExecuteOrderMessage implement IOrderMessage, registering for IOrderMessage
    ///             and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    ///             and ExecuteOrderMessage to the recipient that registered.
    /// </para>
    /// </param><param name="action">The action that will be executed when a message
    ///             of type TMessage is sent.</param>
    void Register<TMessage>(object recipient, object token, bool receiveDerivedMessagesToo, Action<TMessage> action);
