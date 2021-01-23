    public void EstabilishConnection() {
        // You can specify more than one alternative port
        var connection = TryEstabilishConnection(null, 7777, 58900);
        if (connection == null) {
            // Oops!
        }
    }
