    public class ReadRequestData
    {
        public string selectedEmpId { get; set; }
    }
    public IEnumerable<TestViewModel> Test_Read(ReadRequestData data)
    {
        string EmpId = data.selectedEmpId;
        var queryResult = TestRepository.Test_Read(EmpId);
        return queryResult;
    }
