    public class VmFcmNotification
    {
        public string body { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public string sound { get; set; }
        
    }
    public class VmFcmMessage
    {
        /// <summary>
        /// This parameter specifies the recipient of a message.
        /// The value must be a registration token, notification key, or topic.
        /// Do not set this field when sending to multiple topics.
        /// </summary>
        public string to { get; set; }
        /// <summary>
        /// This parameter identifies a group of messages (e.g., with collapse_key: "Updates Available") that can be collapsed,
        /// so that only the last message gets sent when delivery can be resumed.
        /// This is intended to avoid sending too many of the same messages when the device comes back online or becomes active (see delay_while_idle).
        /// Note that there is no guarantee of the order in which messages get sent.
        /// Note: A maximum of 4 different collapse keys is allowed at any given time.
        /// This means a FCM connection server can simultaneously store 4 different send-to-sync messages per client app.
        /// If you exceed this number, there is no guarantee which 4 collapse keys the FCM connection server will keep.
        /// </summary>
        public string collapse_key { get; set; }
        /// <summary>
        /// This parameter, when set to true, allows developers to test a request without actually sending a message.
        /// The default value is false.
        /// </summary>
        public Boolean dry_run { get; set; }
        /// <summary>
        /// This parameter specifies a list of devices (registration tokens, or IDs) receiving a multicast message.
        /// It must contain at least 1 and at most 1000 registration tokens.
        /// Use this parameter only for multicast messaging, not for single recipients.
        /// Multicast messages (sending to more than 1 registration tokens) are allowed using HTTP JSON format only.
        /// </summary>
        public List<string> registration_ids { get; set; }
        public VmFcmNotification notification { get; set; }
    }
