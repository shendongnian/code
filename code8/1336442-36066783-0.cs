     <unity>
        <alias alias="MyTypeConverter" type="Namespace.MyTypeConverter, MyBinary" />
        <containers>
          <container>
    type type="SomeNamespace.IRegister, SomeBinary"
                mapTo="SomeNamespace.Processor, SomeOtherBinary"
                name="MyProcessor">
            <property name="ObjectTypes">
              <array>
                <value value="SomeOtherNameSpace.TextFile, SomeOtherBinary" typeConveter="MyTypeConverter"/>
                <value value="SomeOtherNameSpace.ImageFile, SomeOtherBinary" typeConveter="MyTypeConverter"/>
              </array>
            </property>
          </type>
