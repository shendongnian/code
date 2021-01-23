    public static class Session { 
        public static String Name { get; set; }
    }
    
    //Window1
    public Window1() {
        Session.Name = "Window 1 instantiated.";
    }
    //Window2
    public Window2() {
        txtControl.Text = Session.Name;
    }
