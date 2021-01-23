    public class ProductItemsCacheStore
    {
        private readonly IItemsProductCacheRepository _itemsProductCacheRepo;
        private readonly IProductAvailabilityPricing _productAvailabilityPricing;
        private readonly IProductItemListRepo _productItemListRepo;
        private readonly IItemsPricesCacheRepo _itemsPricesCacheRepo;
    
        private bool _initialized = false;
    
        public ProductItemsCacheStore(
            IItemsProductCacheRepository itemsRepo,
            IProductAvailabilityPricing proxyGoliathApi,
            IProductItemListRepo itemsListsRepo,
            IItemPricesCacheRepo itemPricesRepo)
        {
            _itemsProductCacheRepo = itemsRepo;
            _productAvailabilityPricing = proxyGoliathApi;
            _productItemListRepo = itemsListsRepo;
            _itemsPricesCacheRepo = itemsPricesRepo
        }
    
        public async Task Initialize()
        {
            // Could possibly move these to the constructor as well
            var _items = itemsRepo.GetAllProductOrderListForCache();
            var _itemsLists = itemsListsRepo.GetItemListsForCache();
            var _priceZones = itemPricesRepo.GetAllPriceZonesAndItemPrices();
    
            MergeProductsWithGcn(_items, await _productAvailabilityPricing.GetSkuGcnList());
    
            _initialized = true;
        }
    }
