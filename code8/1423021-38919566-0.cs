    [Test]
    public async Task ThingController__Put__when_thing_is_invalid__then__throws()
    {
        var controller = this.CreateThingController();
        try
        {
            var r = await controller.Put("thing1", this.CreateInvalidThing());
        }
        catch(HttpResponseException hrex) when (hrex.Response.StatusCode == HttpStatusCode.BadRequest)
        {
            return; // implicit pass.
        }
        catch(Exception ex)
        {
            Assert.Fail($"Wrong exception {ex.GetType().Name}");
        }
        Assert.Fail("No exception thrown!");
    }
