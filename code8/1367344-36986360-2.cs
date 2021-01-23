        public List<StageContract> getAllStages() {
            return (new StageController())
               .getAllStages()
               .Values
               .Select(s => new StageContract())
               .ToList();
        }
