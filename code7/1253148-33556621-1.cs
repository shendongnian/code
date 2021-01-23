    public void Discover(ShapeTableBuilder builder)
    {
        builder.Describe("MenuItem")
            .OnDisplaying(displaying => {
                if(_authenticationService.Value.GetAuthenticatedUser() != null)
                    displaying.Shape.Metadata.Alternates.Add("MenuItem__Authenticated");
            });
    }
