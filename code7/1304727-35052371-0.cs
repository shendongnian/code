    public event EventHandler BBBClick;
        protected void OnBBBClick()
        {
            if (BBBClick != null)
            {
                BBBClick(this, new EventArgs());
            }
        }   
        private void button1_Click_1(object sender, EventArgs e)
        {
            OnBBBClick();
        }
