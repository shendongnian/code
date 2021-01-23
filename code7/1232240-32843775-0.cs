    public static class ProductMapper
    {
        static ProductMapper()
        {
            MapProductBDOToDTO();
            MapProductDTOToBDO();
            MapProductCategoryBDOToDTO();
            MapProductCategoryDTOToBDO();
            MapIvaBDOToDTO();
            MapIvaDTOToBDO();
            MapProductSupplierBDOToDTO();
            MapProductSupplierDTOToBDO();
            MapProductPictureBDOToDTO();
            MapProductPictureDTOToBDO();
            MapProductNoteBDOToDTO();
            MapProductNoteDTOToBDO();
            MapStockProductBDOToDTO();
            MapStockProductDTOToBDO();
            MapTagBDOToDTO();
            MapTagDTOToBDO();
        }
        public static TTargetType Convert<TToConvert, TTargetType>(TToConvert toConvert)
        {
            return Mapper.Map<TTargetType>(toConvert);
        }
        private static void MapProductDTOToBDO()
        {
            Mapper.CreateMap<ProductDTO, ProductBDO>();
        }
        private static void MapProductBDOToDTO()
        {
            Mapper.CreateMap<ProductDTO, ProductBDO>().ReverseMap();
        }
        private static void MapProductCategoryDTOToBDO()
        {
            Mapper.CreateMap<ProductCategoryDTO, ProductCategoryBDO>();
        }
        private static void MapProductCategoryBDOToDTO()
        {
            Mapper.CreateMap<ProductCategoryBDO, ProductCategoryDTO>();
        }
        private static void MapIvaDTOToBDO()
        {
            Mapper.CreateMap<IvaDTO, IvaBDO>();
        }
        private static void MapIvaBDOToDTO()
        {
            Mapper.CreateMap<IvaBDO, IvaDTO>();
        }
        private static void MapProductSupplierDTOToBDO()
        {
            Mapper.CreateMap<ProductSupplierDTO, ProductSupplierBDO>();
        }
        private static void MapProductSupplierBDOToDTO()
        {
            Mapper.CreateMap<ProductSupplierDTO, ProductSupplierBDO>().ReverseMap();
        }
        private static void MapProductPictureDTOToBDO()
        {
            Mapper.CreateMap<ProductPictureDTO, ProductPictureBDO>();
        }
        private static void MapProductPictureBDOToDTO()
        {
            Mapper.CreateMap<ProductPictureDTO, ProductPictureBDO>().ReverseMap();
        }
        private static void MapProductNoteDTOToBDO()
        {
            Mapper.CreateMap<ProductNoteDTO, ProductNoteBDO>();
        }
        private static void MapProductNoteBDOToDTO()
        {
            Mapper.CreateMap<ProductNoteDTO, ProductNoteBDO>().ReverseMap();
        }
        private static void MapStockProductDTOToBDO()
        {
            Mapper.CreateMap<StockProductDTO, StockProductBDO>();
        }
        private static void MapStockProductBDOToDTO()
        {
            Mapper.CreateMap<StockProductDTO, StockProductBDO>().ReverseMap();
        }
        private static void MapTagDTOToBDO()
        {
            Mapper.CreateMap<TagDTO, TagBDO>();
        }
        private static void MapTagBDOToDTO()
        {
            Mapper.CreateMap<TagDTO, TagBDO>().ReverseMap();
        }
