    <?xml version="1.0" encoding="utf-8" ?>
    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    
      <assembly name="TestUnityGeneric" />
      <namespace name="TestUnityGeneric"/>
    
      <alias alias="IEventLong" type="TestUnityGeneric.IEvent`1[System.Int64], TestUnityGeneric" />
    
      <container name="Entity">
        <register type="IEventBus`2[IEventLong,long]" mapTo="TestEventBus`2[IEventLong,long]"></register>
    
        <register type="ISender" mapTo="TestSender">
          <constructor>
            <param name="eventBus" dependencyType="IEventBus`2[IEventLong, long]" />
          </constructor>
        </register>
      </container>
    </unity>
