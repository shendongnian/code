    public class ArrayBasicIndexing
    {
      CudafyModule km = CudafyModule.TryDeserialize();
      if (km == null || !km.TryVerifyChecksums())
      {
        km = CudafyTranslator.Cudafy();
        km.Serialize();
