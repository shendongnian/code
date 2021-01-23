    class EncryptingTypedMessageReceiver<TResponse, TRequest> : IDuplexTypedMessageReceiver<TResponse, TRequest> {
      public event EventHandler<TypedRequestReceivedEventArgs<TRequest>> MessageReceived;
      public event EventHandler<ResponseReceiverEventArgs> ResponseReceiverConnected;
      public event EventHandler<ResponseReceiverEventArgs> ResponseReceiverDisconnected;
      private IDuplexStringMessageReceiver string_receiver_;
      private Func<string, ISerializer> serializer_factory_;
      private Dictionary<string, ISerializer> serializers_by_receiver_id_ = new Dictionary<string, ISerializer>();
      public EncryptingTypedMessageReceiver(IDuplexStringMessageReceiver receiver, Func<string, ISerializer> serializer_factory) {
        serializer_factory_ = serializer_factory;
        string_receiver_ = receiver;
        string_receiver_.RequestReceived += OnRequestReceived;
        string_receiver_.ResponseReceiverConnected += OnResponseReceiverConnected;
        string_receiver_.ResponseReceiverDisconnected += OnResponseReceiverDisconnected;
      }
      private void OnRequestReceived(object sender, StringRequestReceivedEventArgs e) {
        TRequest typedRequest = serializers_by_receiver_id_[e.ResponseReceiverId].Deserialize<TRequest>(e.RequestMessage);
        var typedE = new TypedRequestReceivedEventArgs<TRequest>(e.ResponseReceiverId, e.SenderAddress, typedRequest);
        if (MessageReceived != null) {
          MessageReceived(sender, typedE);
        }
      }
      public void SendResponseMessage(string responseReceiverId, TResponse responseMessage) {
        string stringMessage = (string)serializers_by_receiver_id_[responseReceiverId].Serialize(responseMessage);
        string_receiver_.SendResponseMessage(responseReceiverId, stringMessage);
      }
      private void OnResponseReceiverConnected(object sender, ResponseReceiverEventArgs e) {
        if (ResponseReceiverConnected != null)
          ResponseReceiverConnected(sender, e);
        serializers_by_receiver_id_.Add(e.ResponseReceiverId, serializer_factory_(e.ResponseReceiverId));
      }
      private void OnResponseReceiverDisconnected(object sender, ResponseReceiverEventArgs e) {
        if (ResponseReceiverDisconnected != null)
          ResponseReceiverDisconnected(sender, e);
        serializers_by_receiver_id_.Remove(e.ResponseReceiverId);
      }
      public IDuplexInputChannel AttachedDuplexInputChannel {
        get {
          return string_receiver_.AttachedDuplexInputChannel;
        }
      }
      public bool IsDuplexInputChannelAttached {
        get {
          return string_receiver_.IsDuplexInputChannelAttached;
        }
      }
      public void AttachDuplexInputChannel(IDuplexInputChannel duplexInputChannel) {
        string_receiver_.AttachDuplexInputChannel(duplexInputChannel);
      }
      public void DetachDuplexInputChannel() {
        string_receiver_.DetachDuplexInputChannel();
      }
    }
