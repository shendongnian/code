    Keep the running process as a private member of your class then:
    private void pingClicked (object sender, EventArgs e) {
            if( process != null && !process.HasExited )
            {
                process.Kill();
                process=null;
            }
            pinger();
        }
