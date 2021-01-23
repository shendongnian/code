    // List events.
    Events events = request.Execute();
    Console.WriteLine("Upcoming events:");
    if (events.Items != null && events.Items.Count > 0)
    {
    foreach (var eventItem in events.Items)
    {
    string when = eventItem.Start.DateTime.ToString();
    if (String.IsNullOrEmpty(when))
    {
    when = eventItem.Start.Date;
    }
    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
    }
    }
    else
    {
    Console.WriteLine("No upcoming events found.");
    }
    Console.Read();
