    	    <Snippet>
      <Declarations>
        <Literal>
          <ID>PropertyName</ID>
          <Type>String</Type>
          <ToolTip>The property name</ToolTip>
          <Default>NewProperty</Default>
        </Literal>
        <Literal>
          <ID>PropertyType</ID>
          <Type>
          </Type>
          <ToolTip>Replace with the type of the property</ToolTip>
          <Default>string</Default>
        </Literal>
        <Object>
          <ID>PrivateVariable</ID>
          <Type>Object</Type>
          <ToolTip>The name of the private variable</ToolTip>
          <Default>newPropertyValue</Default>
        </Object>
      </Declarations>
      <Code Language="csharp" Kind="method decl"><![CDATA[        private $PropertyType$ _$PrivateVariable$;
        public $PropertyType$ $PropertyName$
        {
            get { return _$PrivateVariable$; }
            set
            {
                SetProperty(value, ref _$PrivateVariable$);
            }
        }]]></Code>
    </Snippet>
