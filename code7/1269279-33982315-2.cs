    static void SolutionOne(ConnectionInfo connection)
    {
        using (SshClient client = new SshClient(connection))
        {
            client.ErrorOccurred += (e, s) =>
            {
                Debug.WriteLine(s.Exception);
            };
    
            client.Connect();
    
            // each RunCommand starts its own/new Shell...
            var sethost = client.RunCommand("export DOCKER_HOST=:2375");
            // ... nothing is kept...
            var infohost = client.RunCommand("export -p");
            if (!infohost.Result.Contains("DOCKER_HOST"))
            {
                Console.WriteLine("sorry, a new shell was started for this command");
            }
            // ... across run commands
            var ps = client.RunCommand("echo has value: $DOCKER");
            Console.WriteLine(ps.Result);
    
            Console.WriteLine("");
            Console.WriteLine("Chain the linux commands...");
            // chain all commands with &&
            var concatAll = client.RunCommand("export DOCKER_HOST=:2375 && export -p | grep DO && echo has value: $DOCKER_HOST");
            // you should see DOCKER_HOST on the last line!
            Console.WriteLine("> see has value: 2375 at the end?");
            Console.WriteLine(concatAll.Result);
        }
    }
    
