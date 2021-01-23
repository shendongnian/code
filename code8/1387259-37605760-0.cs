    private void btnBopIt_Click(object sender, EventArgs e)
    {
        UDPListener myListener = new UDPListener(this);
    }
</>
    public class UDPListener 
    {
    	private Form1 _form { get; set; }
    	public UDPListener (Form1 form) //Assuming your form class is `Form1`
    	{
    		_form = form;
    	}
    
    	//..
    
    }
