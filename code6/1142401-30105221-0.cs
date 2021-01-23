            //Initialize command lists
            Dictionary<string, Action> commands = new Dictionary<string, Action>();
            commands.Add("move", DoMyMove);
            commands.Add("add", ()=> Console.WriteLine(""));
            commands.Add("remove", DoMyRemove);
            commands.Add("close", DoMyClose);
