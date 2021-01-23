	internal class Regexes
	{
		public static void ValidatePhone()
		{
			List<Client> clientList = Program.GetAllClients();
			Regex regex = new Regex(@"Someregex");
			for (int i = 0; i < clientList.Count; i++)
			{
				if (!regex.IsMatch(clientList[i].Phone))
					clientList[i].Phone = "[Netinkama ivestis]";
				}
			}
			//Console.WriteLine(clientList[1].Phone);
		}
	}
