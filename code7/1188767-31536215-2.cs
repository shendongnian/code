    // TLib :     // TLib : mscorlib.dll : {BED7F4EA-1A96-11D2-8F08-00A0C9A6186D}
    importlib("mscorlib.tlb");
    // TLib : OLE Automation : {00020430-0000-0000-C000-000000000046}
    importlib("stdole2.tlb");
    // Forward declare all types defined in this typelib
    interface IAddressData;
    interface ICustomerData;
    interface ICatalogData;
    [
      odl,
      uuid(9C2EF5B0-59BA-3CBE-874A-DA690A595F26),
      version(1.0),
      dual,
      oleautomation,
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.IAddressData")    
    ]
    interface IAddressData : IDispatch {
        [id(0x60020000), propget]
        HRESULT no([out, retval] BSTR* pRetVal);
        [id(0x60020000), propput]
        HRESULT no([in] BSTR pRetVal);
        [id(0x60020002), propget]
        HRESULT road([out, retval] BSTR* pRetVal);
        [id(0x60020002), propput]
        HRESULT road([in] BSTR pRetVal);
    };
    [
      uuid(26736B67-A277-3E81-AAF1-653A936F209E),
      version(1.0),
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.AddressData")
    ]
    coclass AddressData {
        interface _Object;
        [default] interface IAddressData;
    };
    [
      odl,
      uuid(8CCFC141-05C0-3A11-BD3B-C3279AB9B3C1),
      version(1.0),
      dual,
      oleautomation,
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.ICustomerData")    
    ]
    interface ICustomerData : IDispatch {
        [id(0x60020000), propget]
        HRESULT name([out, retval] BSTR* pRetVal);
        [id(0x60020000), propput]
        HRESULT name([in] BSTR pRetVal);
        [id(0x60020002), propget]
        HRESULT address([out, retval] IAddressData** pRetVal);
        [id(0x60020002), propputref]
        HRESULT address([in] IAddressData* pRetVal);
        [id(0x60020004), propget]
        HRESULT order_date([out, retval] DATE* pRetVal);
        [id(0x60020004), propput]
        HRESULT order_date([in] DATE pRetVal);
        [id(0x60020006), propget]
        HRESULT id([out, retval] BSTR* pRetVal);
        [id(0x60020006), propput]
        HRESULT id([in] BSTR pRetVal);
    };
    [
      uuid(9B02E545-4EF6-355E-8CD3-7EC5D2780648),
      version(1.0),
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.CustomerData")
    ]
    coclass CustomerData {
        interface _Object;
        [default] interface ICustomerData;
    };
    [
      odl,
      uuid(8DC4A69C-31FA-311A-8668-9D646AFF1F10),
      version(1.0),
      dual,
      oleautomation,
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.ICatalogData")    
    ]
    interface ICatalogData : IDispatch {
        [id(0x60020000), propget]
        HRESULT customer([out, retval] SAFEARRAY(ICustomerData*)* pRetVal);
        [id(0x60020000), propput]
        HRESULT customer([in] SAFEARRAY(ICustomerData*) pRetVal);
    };
    [
      uuid(5423877C-2618-3D59-8F3A-E1443AC362CA),
      version(1.0),
      custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "Generated.CatalogData")
    ]
    coclass CatalogData {
        interface _Object;
        [default] interface ICatalogData;
    };
