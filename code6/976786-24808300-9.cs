    #import "MyObj.tlb" named_guids auto_rename
    class Logger : public ILogger
    {
    public:
        Logger(MyLogger log)
            : _log(log), _refCount(1)
        {
        }
        virtual ~Logger()
        {
        }
    public: // Implement ILogger
        virtual HRESULT __stdcall raw_WriteLine(BSTR message) {
            // Convert BSTR and write to _log.
            return S_OK;
        }
    public: // Implement IDispatch
        virtual HRESULT __stdcall GetTypeInfoCount(UINT *pctinfo)
        {
            return E_NOTIMPL;
        }
        virtual HRESULT __stdcall GetTypeInfo(UINT iTInfo, LCID lcid, ITypeInfo **ppTInfo)
        {
            return E_NOTIMPL;
        }
        virtual HRESULT __stdcall GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID *rgDispId)
        {
            return E_NOTIMPL;
        }
        virtual HRESULT __stdcall Invoke(DISPID dispIdMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS *pDispParams, VARIANT *pVarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr)
        {
            return E_NOTIMPL;
        }
    public: // Implement IUnknown
        virtual HRESULT __stdcall QueryInterface(REFIID riid, void **ppvObject)
        {
            if (riid == IID_IUnknown) {
                *ppvObject = static_cast<IUnknown*>(this); 
                AddRef();
                return S_OK;
            }
            if (riid == IID_IDispatch) {
                *ppvObject = static_cast<IDispatch*>(this); 
                AddRef();
                return S_OK;
            }
            if (riid == IID_ILogger) {
                *ppvObject = static_cast<ILogger*>(this) ;
                AddRef();
                return S_OK;
            }
            *ppvObject = nullptr;
            return E_NOINTERFACE;
        }
        virtual ULONG __stdcall AddRef()
        {
            return InterlockedIncrement(&_refCount);
        }
        virtual ULONG __stdcall Release()
        {
            return InterlockedDecrement(&_refCount);
        }
    private:
        MyLogger _log;
        long _refCount;
    }
