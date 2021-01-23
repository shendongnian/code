    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Configuration;
    using System.Configuration;
    
    namespace WCF.Sample
    {
    	public class TimestampedTextMsgEncodingBindingElement : MessageEncodingBindingElement, IWsdlExportExtension, IPolicyExportExtension
    	{
    		private readonly TextMessageEncodingBindingElement inner;
    
    		public TimestampedTextMsgEncodingBindingElement(TextMessageEncodingBindingElement inner)
    		{
    			this.inner = inner;
    		}
    
    		public TimestampedTextMsgEncodingBindingElement()
    		{
    			inner = new TextMessageEncodingBindingElement();
    		}
    
    		public TimestampedTextMsgEncodingBindingElement(MessageVersion messageVersion, Encoding writeEnconding)
    		{
    			inner = new TextMessageEncodingBindingElement(messageVersion, writeEnconding);
    		}
    
    		public override MessageEncoderFactory CreateMessageEncoderFactory()
    		{
    			return new TimestampedMsgEncoderFactory(inner.CreateMessageEncoderFactory());
    		}
    
    		#region Pass-through MessageEncoderBindingElement implementations
    
    		public override BindingElement Clone()
    		{
    			return new TimestampedTextMsgEncodingBindingElement((TextMessageEncodingBindingElement)inner.Clone());
    		}
    
    		public override MessageVersion MessageVersion { get { return inner.MessageVersion; } set { inner.MessageVersion = value; } }
    		public Encoding WriteEncoding { get { return inner.WriteEncoding; } set { inner.WriteEncoding = value; } }
    		public Int32 MaxReadPoolSize { get { return inner.MaxReadPoolSize; } set { inner.MaxReadPoolSize = value; } }
    		public Int32 MaxWritePoolSize { get { return inner.MaxWritePoolSize; } set { inner.MaxWritePoolSize = value; } }
    		public XmlDictionaryReaderQuotas ReaderQuotas { get { return inner.ReaderQuotas; } set { inner.ReaderQuotas = value; } }
    
    		public override Boolean CanBuildChannelListener<TChannel>(BindingContext context)
    		{
    			return context.CanBuildInnerChannelListener<TChannel>();
    			//return inner.CanBuildChannelFactory<TChannel>(context);
    		}
    
    		public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
    		{
    			context.BindingParameters.Add(this);
    			return context.BuildInnerChannelListener<TChannel>();
    			//return inner.BuildChannelListener<TChannel>(context);			
    		}
    
    		public void ExportContract(WsdlExporter exporter, WsdlContractConversionContext context)
    		{
    			((IWsdlExportExtension)inner).ExportContract(exporter, context);
    		}
    
    		public void ExportEndpoint(WsdlExporter exporter, WsdlEndpointConversionContext context)
    		{
    			((IWsdlExportExtension)inner).ExportEndpoint(exporter, context);
    		}
    
    		public void ExportPolicy(MetadataExporter exporter, PolicyConversionContext context)
    		{
    			((IPolicyExportExtension)inner).ExportPolicy(exporter, context);
    		}
    
    		#endregion Pass-through MessageEncoderBindingElement implementations
    	}
    }
