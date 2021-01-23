    using (var enumerator = myClassObject.Things.GetEnumerator())
    {
        if (enumerator.MoveNext())
        {
            var firstPair = enumerator.Current;
            // Handle first pair
            while (enumerator.MoveNext())
            {
                var pair = enumerator.Current;
                // Handle subsequent pairs
            }
        }
    }
