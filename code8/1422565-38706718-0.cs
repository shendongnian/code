    [Test, DefaultAutoData]
    public void Create_NameIsNull_ThrowsException(MyPOCO myPOCO) {..}
    internal class DefaultAutoDataAttribute : AutoDataAttribute
    {
      public DefaultAutoDataAttribute()
        : base(new Fixture().Customizations.Add(new UrlSpecimenBuilder()))
      {
      }
    }
