    using System;
    using System.IO;
    using System.ServiceModel.Channels;
    
    namespace WCF.Sample
    {
    	public class TimestampedMsgEncoder : MessageEncoder
    	{
    		public const String TimestampProp = "MsgReceivedTimestamp";
    
    		private MessageEncoder inner;
    
    		public TimestampedMsgEncoder(MessageEncoder inner) { this.inner = inner; }
    
    		public override Message ReadMessage(ArraySegment<Byte> buffer, BufferManager bufferManager, String contentType)
    		{
    			DateTime MsgReceived = DateTime.Now;
    			Message Msg = inner.ReadMessage(buffer, bufferManager, contentType);
    			Msg.Properties.Add(TimestampProp, MsgReceived);
    			return Msg;
    		}
    
    		public override Message ReadMessage(Stream stream, Int32 maxSizeOfHeaders, String contentType)
    		{
    			DateTime MsgReceived = DateTime.Now;
    			Message Msg = inner.ReadMessage(stream, maxSizeOfHeaders, contentType);
    			Msg.Properties.Add(TimestampProp, MsgReceived);
    			return Msg;
    		}
    
    		#region Pass-through MessageEncoder implementations
    
    		public override String ContentType { get { return inner.ContentType; } }
    
    		public override String MediaType { get { return inner.MediaType; } }
    
    		public override MessageVersion MessageVersion { get { return inner.MessageVersion; } }
    
    		public override Boolean IsContentTypeSupported(String contentType) { return inner.IsContentTypeSupported(contentType); }
    
    		public override void WriteMessage(Message message, Stream stream) { inner.WriteMessage(message, stream); }
    
    		public override ArraySegment<Byte> WriteMessage(Message message, Int32 maxMessageSize, BufferManager bufferManager, Int32 messageOffset) { return inner.WriteMessage(message, maxMessageSize, bufferManager, messageOffset); }
    
    		#endregion Pass-through MessageEncoder implementations
    	}
    
    	public class TimestampedMsgEncoderFactory : MessageEncoderFactory
    	{
    		protected readonly MessageEncoderFactory inner;
    
    		protected TimestampedMsgEncoderFactory() { }
    
    		public TimestampedMsgEncoderFactory(MessageEncoderFactory inner)
    		{
    			this.inner = inner;
    		}
    
    		public override MessageEncoder Encoder { get { return new TimestampedMsgEncoder(inner.Encoder); } }
    
    		public override MessageVersion MessageVersion { get { return inner.MessageVersion; } }
    	}
    }
