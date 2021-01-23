    protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            cmdblah.Click += cmdblah_Click;
}
            private void cmdblah_Click(object sender, EventArgs e)
        {
            string Testing = EditUrl("AddNewClient");
            Response.Redirect(Testing);
            //throw new NotImplementedException();
        }
