        // Input string
        string input = "{2,(IDT High Definition Audio CODEC,IDT),(High Definition Audio Device,Microsoft)}";
        // Remove the last }
        input = input.Remove(input.Length - 1);
        // Remove from the begining to the first (
        input = input.Substring(input.IndexOf('('));
        // Remove the first and the last characters
        input = input.Remove(0, 1);
        input = input.Remove(input.Length - 1);
        // At this point, the input value is
        // "IDT High Definition Audio CODEC,IDT),(High Definition Audio Device,Microsoft"
        // Split it, using "),(" as separators
        string[] data = input.Split(new[] { "),(" }, StringSplitOptions.RemoveEmptyEntries);
        // Now, what you want is in data
        foreach (var s in data)
        {
            Console.WriteLine(s);
        }
