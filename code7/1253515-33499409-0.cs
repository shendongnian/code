    // Service side
    [ServiceContract(Name = "chairs-image-generator")]
    public interface IChairsImageArrayGenerator
    {
        // insted byte[] paste desirable type of image
        [OperationContract(Name = "generate-images")]
        IEnumerable<byte[]> GenerateImage(IEnumerable<byte[][]> chairs);
    }
    // Client side
    [ServiceContract(Name = "chairs-image-generator")]
    public interface IChairsImageArrayGeneratorClient
    {
        [OperationContract(Name = "generate-images")]
        IEnumerable<byte[]> GenerateImages(IEnumerable<byte[][]> chairs);
    }
    public class ChairsImageGenerator : IChairsImageArrayGenerator
    {
        public IEnumerable<byte[]> GenerateImages(IEnumerable<byte[][]> chairs)
        {
            // put here your realization 
        }
    }
