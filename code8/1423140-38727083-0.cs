    struct SectionGenerator<TArgs>
    {
        public readonly RegisterSection RegisterSection;
        public readonly Func<TArgs, Task> Generate;
        public SectionGenerator(RegisterSection registerSection, Func<TArgs, Task> generate)
        {
            RegisterSection = registerSection;
            Generate = generate;
        }
    }
    SectionGenerator<TArgs>[] generators =
    {
        new SectionGenerator<TArgs>(RegisterSection.StudentPersonalData,
            async args => schoolRegister.StudentPersonalData = await _sectionGeneratorsProvider.StudentPersonalDataGenerator.GenerateAsync(args);
        // etc.
    }
