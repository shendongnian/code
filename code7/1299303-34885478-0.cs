            var listOfIntArray = new List<int[]>
            {
                new[] {1, 2, 3},
                new[] {4, 5},
                new[] {6}
            };
            var listOfBytes = new List<byte>();
            foreach (var intArray in listOfIntArray)
            {
                var listOfByteArray = intArray.Select(BitConverter.GetBytes);
                foreach (var byteArray in listOfByteArray)
                {
                    listOfBytes.AddRange(byteArray);
                }
            }
