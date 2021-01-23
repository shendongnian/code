    protected async void btnDelete_Click(object sender, EventArgs e)
    {
        Activity a = new Activity();
        a.Id = Convert.ToInt32(txtObjectId.text);
        //await a.Delete(); //Task method
        bool done = await a.Delete(); //Task<bool> method
    }
