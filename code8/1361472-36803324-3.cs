    public interface IPersonReportGeneratorV2 //Or some better name
    {
        string GetReport(IPersonDb personDb, int personId);
    }
    public class LegacyPersonReportWrapper : IPersonReportGeneratorV2
    {
        var generator = new PersonReportGenerator(personDb, personId);
        return generator.Build();
    }
