        public class HttpPostedFileBaseTypeConverter : 
            ITypeConverter<HttpPostedFileBase, byte[]>
        {
            public byte[] Convert(ResolutionContext ctx)
            {
                var fileBase = (HttpPostedFileBase)ctx.SourceValue;
                
                MemoryStream target = new MemoryStream();
                fileBase.InputStream.CopyTo(target);
                return target.ToArray();        
            }
        }
    Usage:
        Mapper.CreateMap<HttpPostedFileBase, byte[]>()
            .ConvertUsing<HttpPostedFileBaseTypeConverter>();
