     var id = this.Request.Body; 
				int bl = (int)id.Length; //this is a dynamic variable.
				byte[] data = new byte[bl]; 
				id.Read(data, 0, bl);
				//string urljson = ownsmtp.AppGlobals.URLEncodedtoJson(System.Text.Encoding.Default.GetString(data));
				Console.WriteLine(System.Text.Encoding.Default.GetString(data));
