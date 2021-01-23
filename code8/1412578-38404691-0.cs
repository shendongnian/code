    public async Task <ActionResult> SendEmail()
    {
        await SendRegisterEmail("Test", "Testagain", "lastTest");
        return View("Index");
    }
