    using System;
    using System.Xml;
    using System.Text;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Configuration;
    using System.Configuration;
    
    namespace WCF.Sample
    {
    	public class TimestampedTextMsgEncodingExtension : BindingElementExtensionElement
    	{
    		private MessageVersion _MessageVersion = MessageVersion.Soap11;
    		private Encoding _Encoding = Encoding.UTF8;
    		private Int32 _MaxReadPoolSize = -1;
    		private Int32 _MaxWritePoolSize = -1;
    		private XmlDictionaryReaderQuotas _ReaderQuotas = null;
    
    		public override Type BindingElementType { get { return typeof(TimestampedTextMsgEncodingBindingElement); } }
    
    		protected override BindingElement CreateBindingElement()
    		{
    			TimestampedTextMsgEncodingBindingElement eb = new TimestampedTextMsgEncodingBindingElement(_MessageVersion, _Encoding);
    			if (_MaxReadPoolSize > -1) eb.MaxReadPoolSize = _MaxReadPoolSize;
    			if (_MaxWritePoolSize > -1) eb.MaxWritePoolSize = MaxWritePoolSize;
    			if (_ReaderQuotas != null) eb.ReaderQuotas = _ReaderQuotas;
    
    			return eb;
    		}
    
    		[ConfigurationProperty("messageVersion", DefaultValue = "Soap11", IsRequired = false)]
    		public String messageVersion
    		{
    			set
    			{
    				switch (value)
    				{
    					case "Soap11":
    						_MessageVersion = MessageVersion.Soap11;
    						break;
    
    					case "Soap12":
    						_MessageVersion = MessageVersion.Soap12;
    						break;
    
    					case "Soap11WSAddressing10":
    						_MessageVersion = MessageVersion.Soap11WSAddressing10;
    						break;
    
    					case "Soap12WSAddressing10":
    						_MessageVersion = MessageVersion.Soap12WSAddressing10;
    						break;
    
    					case "Soap11WSAddressingAugust2004":
    						_MessageVersion = MessageVersion.Soap11WSAddressingAugust2004;
    						break;
    
    					case "Soap12WSAddressingAugust2004":
    						_MessageVersion = MessageVersion.Soap12WSAddressingAugust2004;
    						break;
    
    					default:
    						throw new NotSupportedException("\"" + value + "\" is not a supported message version.");
    				}
    			}
    		}
    
    		[ConfigurationProperty("writeEncoding", DefaultValue = "Utf8TextEncoding", IsRequired = false)]
    		public String writeEncoding
    		{
    			set
    			{
    				switch (value)
    				{
    					case "Utf8TextEncoding":
    						_Encoding = Encoding.UTF8;
    						break;
    
    					case "Utf16TextEncoding":
    						_Encoding = Encoding.Unicode;
    						break;
    
    					case "UnicodeFffeTextEncoding":
    						_Encoding = Encoding.BigEndianUnicode;
    						break;
    
    					default:
    						_Encoding = Encoding.GetEncoding(value);
    						break;
    				}
    			}
    		}
    
    		[ConfigurationProperty("maxReadPoolSize", IsRequired = false)]
    		public Int32 MaxReadPoolSize { get { return _MaxReadPoolSize; } set { _MaxReadPoolSize = value; } }
    
    		[ConfigurationProperty("maxWritePoolSize", IsRequired = false)]
    		public Int32 MaxWritePoolSize { get { return _MaxWritePoolSize; } set { _MaxWritePoolSize = value; } }
    
    		[ConfigurationProperty("readerQuotas", IsRequired = false)]
    		public XmlDictionaryReaderQuotas ReaderQuotas { get { return _ReaderQuotas; } set { _ReaderQuotas = value; } }
    	}
    }
