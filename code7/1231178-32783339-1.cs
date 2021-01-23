        static void Main(string[] args)
        {
            var jsonParser = new DeserializeAndFlatten();
            var installations = jsonParser.ParseJson();
            // FYI we get back a dynamic listing, 
            // so intellisense wont work...
            foreach (var installation in installations)
            {
                Console.WriteLine($"appointmentId: {installation.appointmentId}");
                Console.WriteLine($"installer: {installation.installerName}");
                Console.WriteLine($"installation id: {installation.installationId}");
                Console.WriteLine($"status: {installation.installationStatus}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
