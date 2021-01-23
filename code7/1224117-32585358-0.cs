    class CustomerDataObject:DataObject
    {}
    class CustomerBusinessObject :BusinessObject<CustomerDataObject>
    {}
    class CustomerUIObject :UIObject<CustomerBusinessObject,CustomerDataObject>
    {}
