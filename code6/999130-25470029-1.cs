    <body runat="server">
    <form id="form1" runat="server"> 
    <uc3:IDowner id="IDuser1" runat="server" />
    <%if (IDuser1.owner != "test") 
              { //do stuff 
     } %>
    </form>
    </body>
    public interface IMyMaster
    {
    string owner { get; }
    }
    public class YourMasterPage : MasterPage, IMyMaster
    {
    //enter code here
        public string owner
        {
            get
            {
                this.IDuser1.owner;
            }
        }
    }
