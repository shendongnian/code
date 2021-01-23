    public async Task<IEnumerable<Test>> GetTestsAsync(int schoolyearId)
    {
        return await context.Tests.Where(t => t.SchoolyearId == schoolyearId)
                .Include(t => t.SchoolclassTests.Select(s => s.Schoolclass))
                .Include(t => t.SubjectTests.Select(s => s.Subject))
                .Include(t => t.TestTypeTests.Select(t => t.TestType))                
                .ToListAsync();
    }
