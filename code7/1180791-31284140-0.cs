            string fileContent = @"start ShooterGameServer.exe TheIsland? QueryPort=27015?SessionName=Cain532?MaxPlayers=10?listen?ServerPassword=12345?ServerAdminPassword=******** -nosteamclient -game -server -log";
            Dictionary<string, string> content = new Dictionary<string, string>();
            string selectedSection = fileContent.Split(' ')[2];
            foreach (var singleOption in selectedSection.Split('?'))
            {
                if (singleOption.Split('=').Length == 2)
                {
                    content.Add(singleOption.Split('=')[0], singleOption.Split('=')[1]);                    
                }
            }
