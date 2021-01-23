    public static class StudentServiceExtensions
    {
    public static StudentViewModel CreateViewModel(
        this IStudentService service,
        int id)
    {
        var e = service.GetStudentDetails(id);
        var vm = ConvertStudentToViewModel(e);
        return vm;
    }
    }
