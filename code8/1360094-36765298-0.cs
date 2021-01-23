    private static async Task<List<string>> GetSoapResponsesFromCamerasAsync()
    		{
    			var result = new List<string>();
    
    			using ( var client = new UdpClient() )
    			{
    				var ipEndpoint = new IPEndPoint( IPAddress.Parse( "192.168.1.255" ), 3702 );
    				client.EnableBroadcast = true;
    				try
    				{
    					var soapMessage = GetBytes( CreateSoapRequest() );
    					var timeout = DateTime.Now.AddSeconds( TimeoutInSeconds );
    					await client.SendAsync( soapMessage, soapMessage.Length, ipEndpoint );
    
    					while ( timeout > DateTime.Now )
    					{
    						if ( client.Available > 0 )
    						{
    							var receiveResult = await client.ReceiveAsync();
    							var text = GetText( receiveResult.Buffer );
    							result.Add( text );
    						}
    						else
    						{
    							await Task.Delay( 10 );
    						}
    					}
    				}
    				catch ( Exception exception )
    				{
    					Console.WriteLine( exception.Message );
    				}
    			}
    
    			return result;
    		}
    
    		private static string CreateSoapRequest()
    		{
    			Guid messageId = Guid.NewGuid();
    			const string soap = @"
    			<?xml version=""1.0"" encoding=""UTF-8""?>
    			<e:Envelope xmlns:e=""http://www.w3.org/2003/05/soap-envelope""
    			xmlns:w=""http://schemas.xmlsoap.org/ws/2004/08/addressing""
    			xmlns:d=""http://schemas.xmlsoap.org/ws/2005/04/discovery""
    			xmlns:dn=""http://www.onvif.org/ver10/device/wsdl"">
    			<e:Header>
    			<w:MessageID>uuid:{0}</w:MessageID>
    			<w:To e:mustUnderstand=""true"">urn:schemas-xmlsoap-org:ws:2005:04:discovery</w:To>
    			<w:Action a:mustUnderstand=""true"">http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe</w:Action>
    			</e:Header>
    			<e:Body>
    			<d:Probe>
    			<d:Types>dn:Device</d:Types>
    			</d:Probe>
    			</e:Body>
    			</e:Envelope>
    			";
    
    			var result = string.Format( soap, messageId );
    			return result;
    		}
    
    		private static byte[] GetBytes( string text )
    		{
    			return Encoding.ASCII.GetBytes( text );
    		}
    
    		private static string GetText( byte[] bytes )
    		{
    			return Encoding.ASCII.GetString( bytes, 0, bytes.Length );
    		}
    
    		private string GetAddress( string soapMessage )
    		{
    			var xmlNamespaceManager = new XmlNamespaceManager( new NameTable() );
    			xmlNamespaceManager.AddNamespace( "g", "http://schemas.xmlsoap.org/ws/2005/04/discovery" );
    
    			var element = XElement.Parse( soapMessage ).XPathSelectElement( "//g:XAddrs[1]", xmlNamespaceManager );
    			return element?.Value ?? string.Empty;
    		}
