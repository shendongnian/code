    public String ClientCallback { get; set; }
    private void Page_Init(object sender, EventArgs e)
        {
          GridView.ClientSideEvents.EndCallback = ClientCallback;
        }
