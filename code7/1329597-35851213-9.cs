    public class WebAPIController : ApiController
    {
        [HttpPost]
        [ActionName("Post")]
        public static void GetAllRecognitionsBySupervisorAll([FromBody]ViewModels.AllRecognitionsbyAllSupervisors AllRByAllS)
        {
            DataSet ds = Classes.Recognitions.GetAllRecognitionsBySupervisorAll(AllRByAllS.BeginDate, AllRByAllS.EndDate, AllRByAllS.RecognizedOrSubmitted);
            Classes.DataHelper.SendMeExcelFile(ds, "GetAllRecognitionsBySupervisorAll", AllRByAllS.AuthenticatedUser);
        }
    }
