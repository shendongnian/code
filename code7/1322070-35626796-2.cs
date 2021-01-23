    public partial class PhotoCapturedViewModel : BaseViewModel
    {
        public PhotoCapturedViewModel(IScreen screen, byte[] image) : base(screen, "")
        {
            var memoryStream = new MemoryStream(image);
            Photo = ImageSource.FromStream(() => memoryStream);
            Apply = new DelegateCommand(_ => Publish(APPLY_PHOTO, new RenderedPhoto(image, Description)));
        }
