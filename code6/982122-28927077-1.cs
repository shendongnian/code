    var body = this.Request.Body; 
	int length = (int) body.Length; // this is a dynamic variable
	byte[] data = new byte[length]; 
	body.Read(data, 0, length);				
	Console.WriteLine(System.Text.Encoding.Default.GetString(data));
