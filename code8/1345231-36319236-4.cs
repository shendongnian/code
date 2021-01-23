    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var calFile = new CalendarFile("My Event", new DateTime(2016,3, 30, 5),
                new DateTime(2016,3, 30, 6));
            calFile.Location = "Conf Room 36/2021";
            calFile.Description = "Review meeting";
            calFile.Status = CalendarFile.CfStatus.Busy;
            calFile.allDayEvent = false;
            Response.AddHeader("content-disposition", "attachment; filename=PTO%20Request.ics");
            Response.ContentType = "text/x-vCalendar";
            Response.Write(calFile.ToString());
        }
    }
