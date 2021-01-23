    foreach (EncodingInfo ei1 in Encoding.GetEncodings()) {
    				Encoding e1 = ei1.GetEncoding ();
    				string s1 = "кириллица";
    				System.IO.File.Delete ("script.lua");
    				System.IO.File.AppendAllText ("script.lua", "var = '" + s1 + "'", e1);
    				string s2;
    				try {
    					Lua lua = new Lua ();
    					lua.DoFile ("script.lua");
    					s2 = lua ["var"] as string;
    					foreach (EncodingInfo ei2 in Encoding.GetEncodings()) {
    						Encoding e2 = ei2.GetEncoding ();
    						byte[] bytes = e2.GetBytes (s2);
    						foreach (EncodingInfo ei3 in Encoding.GetEncodings()) {
    							try {
    								Encoding e3 = ei3.GetEncoding ();
    								string s3 = e3.GetString (bytes);
    								if (s1 == s3)
    									Console.WriteLine ("({0})=>({1})=>({2}):[{3}]",e1.HeaderName, e2.HeaderName, e3.HeaderName, s3);
    							} catch { }
    						}
    					}
    				} catch { }
    			}
