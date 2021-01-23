    var result = inp1.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries) // Split with space and hyphen
               .Where(p => p.All(m => Char.IsDigit(m)))   // Get numeric only parts
               .Skip(1)                                   // Skip the first element
               .Take(1)                                   // Take the second one
               .FirstOrDefault();
