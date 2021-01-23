    public class PartialsBundle : Bundle
        {
            public PartialsBundle(string moduleName, string virtualPath)
                : base(virtualPath, new[] { new PartialsTransform(moduleName) })
            {
            }
        }
