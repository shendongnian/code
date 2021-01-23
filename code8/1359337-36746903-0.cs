        private HashSet<string> _hshLineToRemove;
        void ProcessFiles()
        {
            var inputLines = File.ReadLines(_inputFileName);
            var filteredInputLines = inputLines.AsParallel().AsOrdered().Where(line => _hshLineToRemove.Contains(line));
            File.WriteAllLines(_outputFileName, filteredInputLines);
        }
