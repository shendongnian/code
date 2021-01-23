		    Dictionary<string, int> ipList = new Dictionary<string, int>();
			if (!ipList.ContainsKey(new_ip))
			{
				// new ip that exists once.
				ipList.Add(new_ip, 0);
			}
			else
			{
				// dupliate ip - increment number of times duplicated
				ipList[new_ip] += 1;
			}
			foreach (KeyValuePair<string,int> value in ipList)
			{
				textBox1.Text += string.Format(@"IP:{0} Duplicated: {1}\r\n", value.Key, value.Value);
			}
