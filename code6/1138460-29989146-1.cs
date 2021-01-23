    Console.WriteLine("Container has {0} Registrations:",
      container.Registrations.Count());
    foreach (ContainerRegistration item in container.Registrations)
    {
      Console.WriteLine(item.GetMappingAsString());
    }
