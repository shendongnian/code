    private SmtpClient findClient(string site, ref string from)
		{
			// Get the application configuration file.
			Configuration config =
				ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			// Get the collection of the section groups.
			ConfigurationSectionGroupCollection myCollect = config.SectionGroups;
			string host = "";
			string user = "";
			string pass = "";
			SmtpClient client = new SmtpClient();
			foreach (ConfigurationSectionGroup myGroups in myCollect)
			{
				if (myGroups.Name != "Ledgers") continue;
				foreach (ConfigurationSection mySection in myGroups.Sections)
				{
					string ledger = mySection.SectionInformation.Name.ToString();
					Console.WriteLine("Site is " + site + "ledger is " + ledger);
					if (ledger.Equals(site, StringComparison.Ordinal))
					{
						var section = ConfigurationManager.GetSection(
							mySection.SectionInformation.SectionName)
								as NameValueCollection;
						host = section["host"];
						user = section["user"];
						pass = section["pass"];
						from = section["from"];
						Console.WriteLine("\n\nHost " + host + "\nUsername " +
									user + "\nPassword " + pass + "\nFrom " + from);
						client.Port = 25;
						client.Host = host;
						client.Credentials = new System.Net.NetworkCredential(user, pass);
						break;
					}
				}
			}
			return client;
		}
