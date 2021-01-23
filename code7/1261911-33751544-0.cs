        public double GetAverage()
        {
            var rnd = new Random();
            return Enumerable.Range(0, 30) // Create an array of 30 items
                .Select(s => rnd.Next(0, 101)) // Select a random number for each item
                .Average(); // Get the average 
        }
