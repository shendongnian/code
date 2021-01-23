    [TestFixture]
    public class ImageControllerTest
    {
        [Test]
        public void SmokeTest()
        {
            var container = MockRepository.GenerateStrictMock<IContainer>();
            var handler = MockRepository.GenerateStrictMock<IImageHandler>();
            var imageController = new ImageController(container);
    
            string imagePhysicalLocation = @"c:\image.jpg";
    
            Stream imageStream = null;
            container.Expect(x => x.GetImageHandler()).Return(handler);
    
            handler.Expect(x => x.LoadImage(imagePhysicalLocation)).Repeat.Once().Return(imageStream);
    
            handler.Expect(x => x.ConvertToGrayScale(imageStream)).Repeat.Once().Return(imageStream);
    
            var dimensions = new KeyValuePair<int, int>(200, 200);
    
            handler.Expect(x => x.GetDimensions(imageStream)).Repeat.Once().Return(dimensions);
    
            imageController.Execute(imagePhysicalLocation);
    
            container.VerifyAllExpectations();
            handler.VerifyAllExpectations();
        }
    }
    
    public interface IContainer
    {
        IImageHandler GetImageHandler();
    }
    
    public interface IImageHandler
    {
        Stream LoadImage(string physicalLocation);
        KeyValuePair<int, int> GetDimensions(Stream image);
        Stream ConvertToGrayScale(Stream image);
    }
    
    public class ImageController
    {
        private readonly IContainer container;
    
        public ImageController(IContainer container)
        {
            this.container = container;
        }
    
        public void Execute(string imagePhysicalLocation)
        {
            Stream image = container.GetImageHandler().LoadImage(imagePhysicalLocation);
    
            Stream imageInGrayScale = container.GetImageHandler().ConvertToGrayScale(image);
    
            container.GetImageHandler().GetDimensions(imageInGrayScale);
        }
    }
