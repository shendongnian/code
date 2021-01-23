    public partial class FriendRequestControl : UserControl
    {
    	public event EventHandler Accepted;
    	public event EventHandler Rejected;
    
    	public FriendRequestControl()
    	{
    		InitializeComponent();
    	}
    
    	public int RequestId { get; set; }
    	public string FriendName { set { lblFriend.Text = value; } } // TODO add empty/null checks on value
    
    	private void Accept_Click(object sender, EventArgs e)
    	{
    		UpdateRequest(1);
    		OnAccepted();
    	}
    
    	private void Reject_Click(object sender, EventArgs e)
    	{
    		UpdateRequest(2);
    		OnRejected();
    	}
    
    	private bool UpdateRequest(int flag)
    	{
    		// Update db using RequestId and flag
    		// TODO Return True/False based if update succeeds
    		return true; 
    	}
    
    	private void OnAccepted()
    	{
    		var acceptedHandler = Accepted;
    		if (acceptedHandler != null)
    		{
    			acceptedHandler(this, EventArgs.Empty);
    		}
    	}
    
    	private void OnRejected()
    	{
    		var rejectedHandler = Rejected;
    		if (rejectedHandler != null)
    		{
    			rejectedHandler(this, EventArgs.Empty);
    		}
    	}
    }
