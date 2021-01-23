			/// <summary>
    		/// Serializes an object to an xml string
    		/// </summary>
    		public static String Serialize(Object obj)
    		{
    			if (obj == null)
    			{
    				return "";
    			}
    			
    			string xml = string.Empty;			
    
    			try
    			{
    				// Remove xml declaration.
    				XmlWriterSettings settings = new XmlWriterSettings();
    				settings.OmitXmlDeclaration = true;
    
    				using (StringWriter sw = new StringWriter())
    				{
    					using (XmlWriter xw = XmlWriter.Create(sw, settings))
    					{
    						XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
    						xmlSerializer.Serialize(xw, obj);
    					}
    
    					xml = sw.ToString();
    				}
    			}
    			catch (Exception) { }
    
    			return xml;
    		}
    
    		/// <summary>
    		/// Deserializes a xml string to an object
    		/// </summary>
    		public static Object Deserialize(String xml, Type type)
    		{
    			Object obj = null;
    
    			try
    			{
    				if (xml != string.Empty)
    				{
    					using (StringReader sr = new StringReader(xml))
    					{
    						XmlSerializer x = new XmlSerializer(type);
    						obj = x.Deserialize(sr);
    					}
    				}
    			}
    			catch (Exception e)
                {
    				throw new PageException("XmlDeserialization failed", e);
    			}
    
    			return obj;
    		}
