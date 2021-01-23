    buttonSignIn.Click += delegate {
				
				var request = (HttpWebRequest)WebRequest.Create( LOCALHOST + "login");                
				var postData = "email=" + txtMail.Text;
				postData += "&password=" + txtPwd.Text;
				var data = Encoding.ASCII.GetBytes(postData);                
				request.Method = "POST";
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = data.Length;                
				using (var stream = request.GetRequestStream())
				{
					stream.Write(data, 0, data.Length);
				}                
				var response = (HttpWebResponse)request.GetResponse();               
				var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();   
