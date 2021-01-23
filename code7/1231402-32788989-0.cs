    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
      <typeAliases>
        <typeAlias alias="ICriteria"
                   type="Fix.MessageHandling.ICriteria, MoveUnityCode-as-configToXML" />
        <typeAlias alias="ExecutionReportCriteria"
                   type="Fix.MessageHandling.ExecutionReport.Criteria, MoveUnityCode-as-configToXML" />
        <typeAlias alias="ForwardCriteria"
                   type="Fix.MessageHandling.ExecutionReport.ForwardCriteria, MoveUnityCode-as-configToXML" />
    
        <typeAlias alias="IConsumer"
                   type="Fix.MessageHandling.IConsumer, MoveUnityCode-as-configToXML" />
        <typeAlias alias="ForwardConsumer"
                   type="Fix.MessageHandling.ExecutionReport.ForwardConsumer, MoveUnityCode-as-configToXML" />
    
        <typeAlias alias="IProcessor"
                   type="Fix.MessageHandling.IProcessor, MoveUnityCode-as-configToXML" />
        <typeAlias alias="Processor"
                   type="Fix.MessageHandling.Processor, MoveUnityCode-as-configToXML" />
      </typeAliases>
    
      <container>
        <register type="ExecutionReportCriteria" mapTo="ForwardCriteria" name="ForwardCriteria" />
        <register type="IProcessor" mapTo="Processor" />
        <register type="IConsumer" mapTo="ForwardConsumer" name="ForwardConsumer">
          <constructor>
            <param name="processor" dependencyType="IProcessor" />
            <param name="criteria" dependencyType="ExecutionReportCriteria" dependencyName="ForwardCriteria" />
          </constructor>
        </register>
      </container>
    </unity>
