    ...Select(t => new TicketDto
    {
        ID = t.ID,
        Username = t.User.UserName,
        Issue = t.Message.Title,
        Date = t.Message.Date,
    });
    public class TicketDto
    {
        public TicketDto()
	    {
	    }
        ...
