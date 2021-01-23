    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string SendEmail(List<SupervisorToEmail> Supervisors)
    {
        foreach (SupervisorToEmail supervisor in Supervisors)
        {
        }
        return null;
    }
    public class SupervisorToEmail
    {
        public string Contract { get; set; }
        public string SupervisorID { get; set; }
    }
