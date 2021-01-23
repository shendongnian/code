    public interface ITicket
    {
       //properties and methods you want to have all implementations to contain.
    }
    public class Ticket : ITicket
    {
    }
    public class LastTicket :ITicket
    {
    }
    public void PrintTicketFromList(List<ITicket> lstArticles, short intCopies)
    {
    }
