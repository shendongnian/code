    private static List<string> test;
    protected void Page_Init(object sender, EventArgs e) {
        test = test ?? new List<string>();
        // ... additional initalization
    }
